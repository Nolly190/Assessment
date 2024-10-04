namespace Assessment.Application.ViewModels
{
    public class LoginViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string JwtToken { get; set; } = null!;
        public DateTime JwtTokenExpiry { get; set; }
        public string[] Permissions { get; set; } = null!;
    }
}
