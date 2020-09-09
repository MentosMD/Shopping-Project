using FluentValidation;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(c => c.Password)
                .NotEmpty()
                .Equal(c => c.RepeatPassword);
        }
    }
}