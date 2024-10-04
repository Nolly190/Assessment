using Assessment.Application.Constants;
using Assessment.Application.Dtos;
using Assessment.Application.FluentValidators.BookController;
using Assessment.Application.Helpers;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Assessment.Domain.Entities;
using Assessment.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assessment.Application.Implementation
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public IGenericQueryRepository<User> _userQueryRepository;
        public IGenericQueryRepository<UserInRole> _userInRoleQueryRepository;
        public IGenericCommandRepository<UserInRole> _userInRoleCommandRepository;
        public IGenericQueryRepository<Permission> _permissionQueryRepository;
        public IGenericQueryRepository<Role> _roleQueryRepository;
        public IGenericQueryRepository<RolePermission> _rolePermissionQueryRepository;
        public IGenericCommandRepository<User> _userCommandRepository;
        public IValidator<RegistrationRequestViewModel> _registrationValidator;
        public IValidator<LoginRequestViewModel> _loginValidator;
        public AuthenticationService(IMapper mapper,
            IOptions<AppSettings> appSettings,
            IHttpContextAccessor contextAccessor,
            IGenericQueryRepository<User> userQueryRepository,
            IGenericCommandRepository<User> userCommandRepository,
            IGenericQueryRepository<UserInRole> userInRoleQueryRepository,
            IGenericQueryRepository<Permission> permissionQueryRepository,
            IGenericQueryRepository<RolePermission> rolePermissionQueryRepository,
            IGenericQueryRepository<Role> roleQueryRepository,
            IGenericCommandRepository<UserInRole> userInRoleCommandRepository,
            IValidator<RegistrationRequestViewModel> registrationValidator,
            IValidator<LoginRequestViewModel> loginValidator) : base(contextAccessor, appSettings, mapper)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
            _userInRoleQueryRepository = userInRoleQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
            _rolePermissionQueryRepository = rolePermissionQueryRepository;
            _roleQueryRepository = roleQueryRepository;
            _userInRoleCommandRepository = userInRoleCommandRepository;
            _registrationValidator = registrationValidator;
            _loginValidator = loginValidator;
        }

        public async Task<Result<LoginViewModel>> Login(LoginRequestViewModel login)
        {
            var validatorResult = await _loginValidator.ValidateAsync(login);
            if (!validatorResult.IsValid)
            {
                return Result<LoginViewModel>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            var user = (await _userQueryRepository.GetAllAsync(x => x.Email.ToLower() == login.Username.ToLower())).FirstOrDefault();

            if (user == null)
            {
                return Result<LoginViewModel>.Failed(StatusCode.OperationFailed, ResponseMessages.IncorrectUserDetails);
            }

            if (user.LoginFailedCount > _appSettings.LoginFailedAttempt && DateTime.UtcNow < user.LastModified.AddMinutes(_appSettings.LockOutTime))
            {
                return Result<LoginViewModel>.Failed(StatusCode.OperationFailed, ResponseMessages.AccountLockedOut);
            }


            var hashedPassword = HashingUtility.HashPassword(login.Password, _appSettings, user.Salt);

            if (hashedPassword.HashedValue != user.Password)
            {
                user.LoginFailedCount++;
                if (user.LoginFailedCount > _appSettings.LoginFailedAttempt)
                {
                    user.LastModified = DateTime.UtcNow;
                }
                await _userCommandRepository.UpdateAsync(user);
                return Result<LoginViewModel>.Failed(StatusCode.OperationFailed, ResponseMessages.IncorrectUserDetails);
            }

            user.LoginFailedCount = 0;
            var roleIds = (await _userInRoleQueryRepository.GetAllAsync(x => x.UserId == user.Id)).Select(x => x.RoleId).ToList();
            var rolePermissionIds = (await _rolePermissionQueryRepository.GetAllAsync(x => roleIds.Contains(x.RoleId))).Select(x => x.PermissionId);
            var roles = (await _roleQueryRepository.GetAllAsync(x => roleIds.Contains((short)x.Id))).Select(x => x.Name);
            var permission = (await _permissionQueryRepository.GetAllAsync(x => rolePermissionIds.Contains(x.Id))).Select(x => x.Name);


            var generateOTP = GenerateToken(user, roles.ToArray(), permission.ToArray());
            await _userCommandRepository.UpdateAsync(user);
            generateOTP.JwtTokenExpiry = generateOTP.JwtTokenExpiry;
            generateOTP.UserId = user.Id;
            return Result<LoginViewModel>.Success(generateOTP);
        }

        public async Task<Result<LoginViewModel>> Register(RegistrationRequestViewModel register)
        {
            var validatorResult = await _registrationValidator.ValidateAsync(register);
            if (!validatorResult.IsValid)
            {
                return Result<LoginViewModel>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            var userCheck = await _userQueryRepository.AnyAsync(x => x.Email.ToLower() == register.Email.ToLower());
            if (userCheck)
            {
                return Result<LoginViewModel>.Failed(StatusCode.OperationFailed, ResponseMessages.EmailAlreadyExist);
            }

            var hashdetails = HashingUtility.HashPassword(register.Password, _appSettings);
            var user = _mapper.Map<User>(register);
            user.Password = hashdetails.HashedValue;
            user.Salt = hashdetails.Salt;
            user.DateCreated = DateTime.UtcNow;
            var userRecord = await _userCommandRepository.InsertAndRetrieveIdAsync(user);
            var userInRole = await _userInRoleCommandRepository.InsertAndRetrieveIdAsync(new UserInRole
            {
                RoleId = _appSettings.UserRoleId,
                UserId= userRecord.Id,
                DateCreated = DateTime.UtcNow,
                IsDeleted = false,
            });

            var roleIds = (await _userInRoleQueryRepository.GetAllAsync(x => x.UserId == user.Id)).Select(x => x.RoleId).ToList();
            var rolePermissionIds = (await _rolePermissionQueryRepository.GetAllAsync(x => roleIds.Contains(x.RoleId))).Select(x => x.PermissionId);
            var roles = (await _roleQueryRepository.GetAllAsync(x => roleIds.Contains((short)x.Id))).Select(x => x.Name);
            var permission = (await _permissionQueryRepository.GetAllAsync(x => rolePermissionIds.Contains(x.Id))).Select(x => x.Name);
            var generateOTP = GenerateToken(user, roles.ToArray(), permission.ToArray());

            return Result<LoginViewModel>.Success(new LoginViewModel
            {
                JwtToken = generateOTP.JwtToken,
                JwtTokenExpiry = generateOTP.JwtTokenExpiry,
                Email = generateOTP.Email,
                Permissions = generateOTP.Permissions,
                UserId = userRecord.Id,
            });
        }

        private LoginViewModel GenerateToken(User user, string[] role, string[] permissions)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
                               {
                               new Claim("UserId", user.Id.ToString()),
                               new Claim("Email", user.Email),
                               new Claim("FullName",user.Name ),
                               new Claim("Permissions",JsonConvert.SerializeObject(permissions)),
                               new Claim("Role",JsonConvert.SerializeObject(role)),
                               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var jwtTokenExpiration = DateTime.UtcNow.AddMinutes(_appSettings.JwtTokenTimeout);
            var token = new JwtSecurityToken(
            issuer: _appSettings.JwtIssuer,
            audience: _appSettings.JwtAudience,
            claims: claims.ToArray(),
            expires: jwtTokenExpiration,
            signingCredentials: credentials
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginViewModel
            {
                Email = user.Email,
                JwtToken = jwtToken,
                JwtTokenExpiry = jwtTokenExpiration,
                Permissions = permissions,
                UserId = user.Id,
            };
        }


    }
}
