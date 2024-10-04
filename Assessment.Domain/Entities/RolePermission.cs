namespace Assessment.Domain.Entities
{
    public partial class RolePermission : BaseEntity
    {
        public short RoleId { get; set; }
        public short PermissionId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
