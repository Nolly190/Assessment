using Asp.Versioning;
using Assessment.Application.Dtos;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [EnableRateLimiting("fixedLimit")]
    public class UserController : BaseController
    {

        public IAuthenticationService _authService;
        public UserController(IAuthenticationService authService)
        {
            _authService = authService;
        }


        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<int>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<int>))]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestViewModel model)
        {
            return ReturnResponse(await _authService.Login(model));
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<int>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<int>))]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestViewModel model)
        {
            return ReturnResponse(await _authService.Register(model));
        }


        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaginationResult<List<UserViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PaginationResult<List<UserViewModel>>))]
        [HttpPost]
        [Authorize(Policy = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromBody] SearchFilter model)
        {
            return ReturnResponse(await _authService.GetUsers(model));
        }
        
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<UserViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<UserViewModel>))]
        [HttpGet("{id}")]
        [Authorize(Policy = "GetSingleUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            return ReturnResponse(await _authService.GetUser(id));
        }
        
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<UserViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<UserViewModel>))]
        [HttpPost("block")]
        [Authorize(Policy = "GetSingleUser")]
        public async Task<IActionResult> BlockUser([FromBody]BanUserViewModel model)
        {
            return ReturnResponse(await _authService.BanCustomer(model,true));
        }
        
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<UserViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<UserViewModel>))]
        [HttpPost("unblock")]
        [Authorize(Policy = "GetSingleUser")]
        public async Task<IActionResult> unBlockUser([FromBody]BanUserViewModel model)
        {
            return ReturnResponse(await _authService.BanCustomer(model,false));
        }
    }
}
