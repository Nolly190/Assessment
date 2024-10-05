using Assessment.Domain.Enum;

namespace Assessment.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsBanned { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerType CustomerType { get; set; }
        public int LoginFailedCount { get; set; }
    }
}
