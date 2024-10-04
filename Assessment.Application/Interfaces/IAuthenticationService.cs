using Assessment.Application.Dtos;
using Assessment.Application.ViewModels;

namespace Assessment.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<LoginViewModel>> Login(LoginRequestViewModel login);
        Task<Result<LoginViewModel>> Register(RegistrationRequestViewModel register);
    }
}
