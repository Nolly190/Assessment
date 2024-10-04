namespace Assessment.Domain.Entities
{
    public class Role :BaseEntity
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
