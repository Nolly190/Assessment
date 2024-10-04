using Assessment.Domain.Entities;
using Assessment.Infrastructure.External_Services.Interface;
using Assessment.Infrastructure.Repositories.Interfaces;
using Quartz;

namespace Assessment.Worker.Jobs
{
    [DisallowConcurrentExecution]
    public class ReservationCheckJob : IJob
    {
        private readonly ILogger<ReservationCheckJob> _logger;
        public readonly IGenericCommandRepository<Book> _bookCommandRepo;
        public readonly IGenericQueryRepository<Book> _bookQueryRepo;
        public readonly IGenericQueryRepository<User> _userQueryRepo;
        public readonly IGenericCommandRepository<BookReservation> _bookReservationCommandRepo;
        public readonly IGenericCommandRepository<BookReservationNotification> _bookReservationNotificationCommandRepo;
        public readonly IGenericQueryRepository<BookReservation> _bookReservationQueryRepo;
        public readonly INotificationService _notificationService;
        public ReservationCheckJob(ILogger<ReservationCheckJob> logger,
            IGenericCommandRepository<Book> bookCommandRepo,
            IGenericQueryRepository<Book> bookQueryRepo,
            IGenericQueryRepository<User> userQueryRepo,
            IGenericCommandRepository<BookReservation> bookReservationCommandRepo,
            IGenericCommandRepository<BookReservationNotification> bookReservationNotificationCommandRepo,
            IGenericQueryRepository<BookReservation> bookReservationQueryRepo = null,
            INotificationService notificationService = null)
        {
            _logger = logger;
            _bookCommandRepo = bookCommandRepo;
            _bookQueryRepo = bookQueryRepo;
            _userQueryRepo = userQueryRepo;
            _bookReservationCommandRepo = bookReservationCommandRepo;
            _bookReservationNotificationCommandRepo = bookReservationNotificationCommandRepo;
            _bookReservationQueryRepo = bookReservationQueryRepo;
            _notificationService = notificationService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var records = (await _bookReservationQueryRepo.GetAllAsync(x => !x.IsReturned && x.ExpectedDateOfReturn < DateTime.UtcNow)).OrderByDescending(x=>x.DateCreated).ToList();
            var books = await _bookQueryRepo.GetAllAsync(x => records.Select(x => x.BookId).Contains(x.Id));
            foreach (var record in records)
            {
                try
                {
                    var book = books.FirstOrDefault(x => x.Id == record.BookId);
                    if (book.Status != Domain.Enum.ReservationStatus.Reserved)
                    {
                        continue;
                    }
                    book.Status = Domain.Enum.ReservationStatus.Free;
                    book.LastModified = DateTime.UtcNow;
                    record.IsReturned = true;
                    record.LastModified = DateTime.UtcNow;
                    await _bookCommandRepo.UpdateAsync(book);
                    await _bookReservationCommandRepo.UpdateAsync(record);
                    var nextNotification = (await _bookReservationQueryRepo.GetAllAsync(x => x.BookId == record.BookId && !x.IsReturned)).OrderBy(x => x.DateCreated).FirstOrDefault();

                    if (nextNotification != null)
                    {
                        var nextReservedUser = await _userQueryRepo.GetAsync(nextNotification.CustomerId);
                        _notificationService.SendNotification(book, nextReservedUser);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occured while processing Job {ex.ToString()}");
                }
            }
        }

    }
}
