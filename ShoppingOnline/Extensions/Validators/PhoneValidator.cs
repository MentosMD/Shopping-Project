using FluentValidation;
using FluentValidation.Validators;

namespace ShoppingOnline.Validations
{
    public static class PhoneValidator
    {
        public static IRuleBuilderOptions<T, string> MatchPhoneNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator(@"(?:[0-9]\-?){6,14}[0-9]$"));
        }
    }
}