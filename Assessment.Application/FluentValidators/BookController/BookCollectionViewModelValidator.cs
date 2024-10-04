using Assessment.Application.ViewModels;
using FluentValidation;

namespace Assessment.Application.FluentValidators.BookController
{
    public class BookCollectionViewModelValidator : AbstractValidator<BookCollectionViewModel>
    {
        public BookCollectionViewModelValidator()
        {
            RuleFor(x => x.BookId).NotNull().NotEqual(0);
            RuleFor(x => x.CustomerId).NotNull().NotEqual(0);
            RuleFor(x => x.DateOfReturn).GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
