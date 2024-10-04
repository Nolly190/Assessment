namespace Assessment.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } =DateTime.UtcNow;
    }
}
