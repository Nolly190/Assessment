using Assessment.Application.ViewModels;
using FluentValidation;

namespace Assessment.Application.FluentValidators.BookController
{
    public class BookReservationValidator : AbstractValidator<BookReservationViewModel>
    {
        public BookReservationValidator()
        {
            RuleFor(x => x.BookId).NotNull().NotEqual(0);
        }
    }
}
