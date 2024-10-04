using System.ComponentModel.DataAnnotations;

namespace Assessment.Application.ViewModels
{
    public class LoginRequestViewModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
