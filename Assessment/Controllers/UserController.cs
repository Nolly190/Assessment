using Asp.Versioning;
using Assessment.Application.Dtos;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
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


    }
}
