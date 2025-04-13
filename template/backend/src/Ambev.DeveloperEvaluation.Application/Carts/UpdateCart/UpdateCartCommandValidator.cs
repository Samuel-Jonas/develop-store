using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}