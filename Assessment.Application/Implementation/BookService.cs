
using Assessment.Application.Constants;
using Assessment.Application.Dtos;
using Assessment.Application.FluentValidators;
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
    public class BookService : BaseService, IBookService
    {
        public readonly IGenericCommandRepository<Book> _bookCommandRepo;
        public readonly IGenericQueryRepository<Book> _bookQueryRepo;
        public readonly IGenericQueryRepository<User> _userQueryRepo;
        public readonly IGenericCommandRepository<BookReservation> _bookReservationCommandRepo;
        public readonly IGenericCommandRepository<BookReservationNotification> _bookReservationNotificationCommandRepo;
        public readonly IGenericQueryRepository<BookReservation> _bookReservationQueryRepo;
        public readonly INotificationService _notificationService;
        public readonly IValidator<AddBookViewModel> _bookValidator;
        public readonly IValidator<BookCollectionViewModel> _bookCollectionValidator;
        public readonly IValidator<BookReservationViewModel> _bookReservationValidator;
        public BookService(IOptions<AppSettings> appSettings,
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
            INotificationService notificationService)
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
        }
        public async Task<Result<int>> AddBook(AddBookViewModel entity)
        {
            var validatorResult = await _bookValidator.ValidateAsync(entity);
            if (!validatorResult.IsValid)
            {
                return Result<int>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            if (await _bookQueryRepo.AnyAsync(x => x.Name.ToLower() == entity.Name.ToLower() && x.DatePublished == x.DatePublished && x.Author.ToLower() == entity.Author.ToLower()))
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.RecordExists);
            }

            var model = _mapper.Map<Book>(entity);
            model.Status = Domain.Enum.ReservationStatus.Free;
            return Result<int>.Success(await _bookCommandRepo.InsertAsync(model));
        }

        public async Task<Result<int>> BookCollection(BookCollectionViewModel entity)
        {
            var validatorResult = await _bookCollectionValidator.ValidateAsync(entity);
            if (!validatorResult.IsValid)
            {
                return Result<int>.Failed(_mapper.Map<List<Error>>(validatorResult.Errors));
            }

            var book = await _bookQueryRepo.GetAsync(entity.BookId);
            if (book is null)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.NoRecordFound);
            }


            var previousReservation = new BookReservation();
            var previousReservations = (await _bookReservationQueryRepo.GetAllAsync(x => !x.IsReturned && x.BookId == entity.BookId)).OrderBy(x => x.DateCreated);
            if (previousReservations.Any())
            {
                previousReservation = previousReservations.FirstOrDefault();
                if (previousReservation.CustomerId != entity.CustomerId)
                {
                    return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.BookReservedByAnotherCustomer);
                }
            }

            if (book.Status != Domain.Enum.ReservationStatus.Free && entity.CustomerId != previousReservation.CustomerId)
            {
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.BookNotAvailable);
            }

            previousReservation.IsReturned = true;
            previousReservation.LastModified = DateTime.UtcNow;
            var reservation = _mapper.Map<BookReservation>(entity);
            reservation.CustomerId = entity.CustomerId;
            book.Status = Domain.Enum.ReservationStatus.Collected;
            reservation.ExpectedDateOfReturn = entity.DateOfReturn;
            await _bookReservationCommandRepo.UpdateAsync(previousReservation);
            await _bookCommandRepo.UpdateAsync(book);
            return Result<int>.Success(await _bookReservationCommandRepo.InsertAsync(reservation));
        }

        public async Task<Result<int>> BookReturn(BookReservationViewModel entity)
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
                return Result<int>.Failed(StatusCode.OperationFailed, ResponseMessages.BookWasNotCollected);
            }

            var lastReservation = (await _bookReservationQueryRepo.GetAllAsync(x => x.BookId == entity.BookId && !x.IsReturned)).OrderBy(x => x.DateCreated).FirstOrDefault();
            lastReservation.IsReturned = true;
            book.Status = Domain.Enum.ReservationStatus.Free;
            await _bookReservationCommandRepo.UpdateAsync(lastReservation);
            lastReservation = (await _bookReservationQueryRepo.GetAllAsync(x => x.BookId == entity.BookId && !x.IsReturned)).OrderBy(x => x.DateCreated).FirstOrDefault();
            
            if (lastReservation != null)
            {
                var nextReservedUser = await _userQueryRepo.GetAsync(lastReservation.CustomerId);
                _notificationService.SendNotification(book,nextReservedUser);
            }
            return Result<int>.Success(await _bookCommandRepo.UpdateAsync(book));
        }

        public async Task<Result<BookViewModel>> GetBook(int bookId)
        {
            var book = await _bookQueryRepo.GetAsync(bookId);
            if (book == null)
            {
                return Result<BookViewModel>.Failed(StatusCode.OperationFailed, ResponseMessages.NoRecordFound);
            }
            var bookResponse = _mapper.Map<BookViewModel>(book);

            if (book.Status != Domain.Enum.ReservationStatus.Free)
            {
                var bookReservation = (await _bookReservationQueryRepo.GetAllAsync(x => x.BookId == bookId && !x.IsReturned))?.FirstOrDefault();
                if (bookReservation != null)
                {
                    bookResponse.DateOfReturn = bookReservation.ExpectedDateOfReturn;
                }
            }
            return Result<BookViewModel>.Success(bookResponse);
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

        public async Task<PaginationResult<List<BookViewModel>>> SearchBooks(SearchFilter filter)
        {
            var books = await _bookQueryRepo.GetPaginatedAsync();
            books = FilterBooks(books, filter);
            var response = books.ToPagedResponse(filter);
            var bookResponse = _mapper.Map<List<BookViewModel>>(response.Data.ToList());
            return PaginationResult<List<BookViewModel>>.Success(bookResponse, response.TotalPages, response.TotalCount);
        }

        private IQueryable<Book> FilterBooks(IQueryable<Book> query, SearchFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            foreach (var item in filter.SearchParams)
            {
                switch (item.Key.ToLower())
                {
                    case "name":
                        query = query.Where(x => x.Name.Contains(item.Value));
                        break;
                    case "authur":
                        query = query.Where(x => x.Author.Contains(item.Value));
                        break;
                    case "datepublished":
                        query = query.Where(x => x.DatePublished == Convert.ToDateTime(item.Value));
                        break;
                    case "datecreated":
                        query = query.Where(x => x.DateCreated == Convert.ToDateTime(item.Value));
                        break;
                    default:
                        break;
                }
            }
            return query;
        }
    }
}
