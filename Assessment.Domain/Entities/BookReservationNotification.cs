namespace Assessment.Domain.Entities
{
    public class BookReservationNotification : BaseEntity
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public bool IsNotified { get; set; }
    }
}
