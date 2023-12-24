using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;


namespace Pacagroup.Ecommerce.Application.Validator
{
    public class DiscountDotValidator : AbstractValidator<DiscountDto>
    {
        public DiscountDotValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Percent).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
