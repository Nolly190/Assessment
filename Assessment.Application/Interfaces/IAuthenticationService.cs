using Assessment.Application.Dtos;
using Assessment.Application.ViewModels;

namespace Assessment.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<LoginViewModel>> Login(LoginRequestViewModel login);
        Task<Result<LoginViewModel>> Register(RegistrationRequestViewModel register);
        Task<PaginationResult<List<UserViewModel>>> GetUsers(SearchFilter options);
        Task<Result<UserViewModel>> GetUser(int customerId);
        Task<Result<int>> BanCustomer(BanUserViewModel model,bool action);
    }
}
