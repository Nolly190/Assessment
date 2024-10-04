using Assessment.Domain.Enum;

namespace Assessment.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
