using FluentValidation;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class LoginModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginModelValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(c => c.Password)
                .NotEmpty();
        }
    }
}