using FluentValidation;
using ShoppingOnline.Models;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Validations
{
    public class ProfileModelValidator : AbstractValidator<ProfileViewModel>
    {
        public ProfileModelValidator()
        {
            RuleFor(c => c.FName)
                .MaximumLength(255)
                .NotEmpty();
            RuleFor(c => c.LName)
                .MaximumLength(255)
                .NotEmpty();
            RuleFor(c => c.Phone)
                .MatchPhoneNumberRule();
        }
    }
}