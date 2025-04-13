using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("User ID is required.");
    }
}