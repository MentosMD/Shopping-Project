using FluentValidation;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class RegisterModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(c => c.Password)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(c => c.FName)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(c => c.LName)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(c => c.RepeatPassword)
                .NotEmpty()
                .Equal(x => x.Password);
        }
    }
}