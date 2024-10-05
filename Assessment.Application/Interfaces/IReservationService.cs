using Assessment.Application.Dtos;
using Assessment.Application.ViewModels;

namespace Assessment.Application.Interfaces
{
    public interface IReservationService
    {
        Task<Result<int>> ReservationNotification(BookReservationViewModel entity);
        Task<Result<int>> ReserveBook(BookReservationViewModel entity);
        Task<PaginationResult<List<ReservationViewModel>>> GetAllReservations(SearchFilter param);
        Task<Result<ReservationViewModel>> GetReservation(int id);
        Task<PaginationResult<List<ReservationNotificationViewModel>>> GetAllReservationNotifications(SearchFilter param);
    }
}
