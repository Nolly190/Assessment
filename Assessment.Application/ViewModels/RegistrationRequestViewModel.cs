using System.ComponentModel.DataAnnotations;

namespace Assessment.Application.ViewModels
{
    public class RegistrationRequestViewModel
    {
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  string PhoneNumber { get; set; }
        public  string Password { get; set; }
    }
}
