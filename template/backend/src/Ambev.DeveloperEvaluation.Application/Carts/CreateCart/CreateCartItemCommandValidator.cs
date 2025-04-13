using System.Globalization;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("You must provide a user id.");
        
        RuleFor(cart => cart.Date)
            .NotEmpty()
            .WithMessage("You must provide a valid date.");
        
        RuleFor(cart => cart.Date)
            .Must(date => DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            .WithMessage("Date must be a valid date (yyyy-MM-dd)");

        RuleForEach(cart => cart.Products)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.ProductId).NotEmpty().WithMessage("You must provide a product id.");
                item.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("You must provide at least one quantity.");
            });
    }
}