using Assessment.Application.ViewModels;
using Assessment.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.FluentValidators
{
    public class LoginValidator : AbstractValidator<LoginRequestViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(100);
        }
    } 
}
