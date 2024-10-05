using Assessment.Application.Dtos;
using Assessment.Application.ViewModels;

namespace Assessment.Application.Interfaces
{
    public interface IBookService
    {
        Task<Result<int>> AddBook(AddBookViewModel entity);
        Task<Result<int>> BookCollection(BookCollectionViewModel entity);
        Task<Result<int>> BookReturn(BookReservationViewModel entity);
        Task<Result<BookViewModel>> GetBook(int bookId);
        Task<PaginationResult<List<BookViewModel>>> SearchBooks(SearchFilter filter);
    }
}
