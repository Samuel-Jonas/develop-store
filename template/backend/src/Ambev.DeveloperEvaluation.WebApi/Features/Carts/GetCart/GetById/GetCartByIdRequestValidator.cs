using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetById;

public class GetCartByIdRequestValidator : AbstractValidator<GetCartByIdRequest>
{
    public GetCartByIdRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart id is required.");
    }
}