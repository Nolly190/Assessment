using Assessment.Application.ViewModels;
using Assessment.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.FluentValidators.BookController
{
    public class BookValidator : AbstractValidator<AddBookViewModel>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Author).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.DatePublished).NotEqual(DateTime.MinValue);
        }
    }
}
