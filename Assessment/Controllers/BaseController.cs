using Assessment.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ReturnResponse(dynamic result)
        {
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
