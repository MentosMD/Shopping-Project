using FluentValidation;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class OrderModelValidator : AbstractValidator<OrderViewModel>
    {
        public OrderModelValidator()
        {
            RuleFor(o => o.TotalSum)
                .NotEmpty();
            RuleFor(o => o.OrderItems)
                .NotEmpty();
        }
    }
}