using Assessment.Domain.Enum;
using System.Data;
using System.Security;

namespace Assessment.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerType CustomerType { get; set; }
        public string? Salt { get; set; }
        public string? Password { get; set; }
        public int LoginFailedCount { get; set; }
    }
}
