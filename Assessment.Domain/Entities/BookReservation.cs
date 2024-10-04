using Assessment.Domain.Enum;

namespace Assessment.Domain.Entities
{
    public class BookReservation : BaseEntity
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ExpectedDateOfReturn { get; set; }
    }
}
