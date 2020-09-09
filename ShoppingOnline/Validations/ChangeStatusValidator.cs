using FluentValidation;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class ChangeStatusValidator : AbstractValidator<ChangeStatusViewModel>
    {
        public ChangeStatusValidator()
        {
            RuleFor(c => c.IdOrder)
                .NotEmpty();
            RuleFor(c => c.Status)
                .NotEmpty();
        }
    }
}