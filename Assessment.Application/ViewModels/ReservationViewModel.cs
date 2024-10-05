using Assessment.Domain.Entities;

namespace Assessment.Application.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string BookName { get; set; }
        public int BookId { get; set; }
        public string CustomerName { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ExpectedDateOfReturn { get; set; }
    }
}
