using Assessment.Application.ViewModels;
using FluentValidation;

namespace Assessment.Application.FluentValidators
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequestViewModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty().Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
        }
    }
}
