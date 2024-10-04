namespace Assessment.Domain.Entities
{
    public class UserInRole : BaseEntity
    {
        public int UserId { get; set; }
        public short RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }

}
