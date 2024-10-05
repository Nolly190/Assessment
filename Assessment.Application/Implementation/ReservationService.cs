
using Assessment.Application.Constants;
using Assessment.Application.Dtos;
using Assessment.Application.Helpers;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Assessment.Domain.Entities;
using Assessment.Infrastructure.External_Services.Interface;
using Assessment.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Assessment.Application.Implementation
{
    public class ReservationService : BaseService, IReservationService
    {
        public readonly IGenericCommandRepository<Book> _bookCommandRepo;
        public readonly IGenericQueryRepository<Book> _bookQueryRepo;
        public readonly IGenericCommandRepository<BookReservation> _bookReservationCommandRepo;
        public readonly IGenericCommandRepository<BookReservationNotification> _bookReservationNotificationCommandRepo;
        public readonly IGenericQueryRepository<BookReservationNotification> _bookReservationNotificationQueryRepo;
        public readonly IGenericQueryRepository<BookReservation> _bookReservationQueryRepo;
        public readonly INotificationService _notificationService;
        public readonly IValidator<AddBookViewModel> _bookValidator;
        public readonly IValidator<BookCollectionViewModel> _bookCollectionValidator;
        public readonly IValidator<BookReservationViewModel> _bookReservationValidator;
        public ReservationService(IOptions<AppSettings> appSettings,
            IGenericCommandRepository<Book> bookCommandRepo,
            IGenericQueryRepository<Book> bookQueryRepo,
            IGenericCommandRepository<BookReservation> bookReservationCommandRepo,
            IGenericQueryRepository<BookReservation> bookReservationQueryRepo,
            IHttpContextAccessor contextAccessor,
            IMapper mapper,
            IValidator<AddBookViewModel> bookValidator,
            IValidator<BookReservationViewModel> bookReservationValidator,
            IValidator<BookCollectionViewModel> bookCollectionValidator,
            IGenericCommandRepository<BookReservationNotification> bookReservationNotificationCommandRepo,
            INotificationService notificationService,
            IGenericQueryRepository<BookReservationNotification> bookReservationNotificationQueryRepo)
            : base(contextAccessor, appSettings, mapper)
        {
            _bookCommandRepo = bookCommandRepo;
            _bookQueryRepo = bookQueryRepo;
            _bookReservationCommandRepo = bookReservationCommandRepo;
            _bookReservationQueryRepo = bookReservationQueryRepo;
            _bookValidator = bookValidator;
            _bookReservationValidator = bookReservationValidator;
            _bookCollectionValidator = bookCollectionValidator;
            _bookReservationNotificationCommandRepo = bookReservationNotificationCommandRepo;
            _notificationService = notificationService;
            _bookReservationNotificationQueryRepo = bookReservationNotificationQueryRepo;
        }

        public async Task<PaginationResult<List<ReservationNotificationViewModel>>> GetAllReservationNotifications(SearchFilter param)
        {
            var reservation = await _bookReservationNotificationQueryRepo.GetAllWithIncludeAsync(null, new string[] { "Book", "Customer" });
            reservation = FilterReservationNotification(reservation, param);
            var response = reservation.ToPagedResponse(param);
            var bookResponse = _mapper.Map<List<ReservationNotificationViewModel>>(response.Data.ToList());
            return PaginationResult<List<ReservationNotificationViewModel>>.Success(bookResponse, response.TotalPages, response.TotalCount);
        }

        public async Task<PaginationResult<List<ReservationViewModel>>> GetAllReservations(SearchFilter param)
        {
            var books = await _bookReservationQueryRepo.GetAllWithIncludeAsync(null, new string[] { "Book", "User" });
            books = FilterReservation(books, param);
            var response = books.ToPagedResponse(param);
            var bookResponse = _mapper.Map<List<ReservationViewModel>>(response.Data.ToList());
            return PaginationResult<List<ReservationViewModel>>.Success(bookResponse, response.TotalPages, response.TotalCount);
        }

        public Task<Result<ReservationViewModel>> GetReservation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<int>> ReservationNotification(BookReservationViewModel entity)
        {
            var validatorResult = await _bookReservationValidator.ValidateAsync(entity);
            if (!validatorResult.IsValid)
            {
                return Result<int>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            var book = await _bookQueryRepo.GetAsync(entity.BookId);
            if (book is null)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.NoRecordFound);
            }

            if (book.Status == Domain.Enum.ReservationStatus.Free)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.BookWasNotReserved);
            }

            var model = _mapper.Map<BookReservationNotification>(entity);
            model.CustomerId = SignedInCustomerId;

            return Result<int>.Success(await _bookReservationNotificationCommandRepo.InsertAsync(model));
        }

        public async Task<Result<int>> ReserveBook(BookReservationViewModel entity)
        {
            var validatorResult = await _bookReservationValidator.ValidateAsync(entity);
            if (!validatorResult.IsValid)
            {
                return Result<int>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            var book = await _bookQueryRepo.GetAsync(entity.BookId);
            if (book is null)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.NoRecordFound);
            }

            if (book.Status != Domain.Enum.ReservationStatus.Free)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.BookNotAvailable);
            }

            var reservation = _mapper.Map<BookReservation>(entity);
            reservation.CustomerId = SignedInCustomerId;
            book.Status = Domain.Enum.ReservationStatus.Reserved;
            reservation.ExpectedDateOfReturn = DateTime.UtcNow.AddHours(_appSettings.ReservationTimeLimit);
            await _bookCommandRepo.UpdateAsync(book);
            return Result<int>.Success(await _bookReservationCommandRepo.InsertAsync(reservation));
        }
        private IQueryable<BookReservationNotification> FilterReservationNotification(IQueryable<BookReservationNotification> query, SearchFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            foreach (var item in filter.SearchParams)
            {
                switch (item.Key.ToLower())
                {
                    case "bookname":
                        query = query.Where(x => x.Book.Name.Contains(item.Value));
                        break;
                    case "isreturned":
                        query = query.Where(x => x.IsNotified == bool.Parse(item.Value));
                        break;
                    case "customername":
                        query = query.Where(x => x.Customer.Name.Contains(item.Value));
                        break;
                    case "datecreated":
                        query = query.Where(x => x.DateCreated.Date == Convert.ToDateTime(item.Value));
                        break;
                    default:
                        break;
                }
            }
            return query;
        }
        private IQueryable<BookReservation> FilterReservation(IQueryable<BookReservation> query, SearchFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            foreach (var item in filter.SearchParams)
            {
                switch (item.Key.ToLower())
                {
                    case "bookname":
                        query = query.Where(x => x.Book.Name.Contains(item.Value));
                        break;
                    case "isreturned":
                        query = query.Where(x => x.IsReturned == bool.Parse(item.Value));
                        break;
                    case "customername":
                        query = query.Where(x => x.User.Name.Contains(item.Value));
                        break;
                    case "datecreated":
                        query = query.Where(x => x.DateCreated.Date == Convert.ToDateTime(item.Value));
                        break;
                    case "expecteddateofreturn":
                        query = query.Where(x => x.ExpectedDateOfReturn.HasValue && x.ExpectedDateOfReturn.Value == Convert.ToDateTime(item.Value));
                        break;
                    default:
                        break;
                }
            }
            return query;
        }
    }
}
