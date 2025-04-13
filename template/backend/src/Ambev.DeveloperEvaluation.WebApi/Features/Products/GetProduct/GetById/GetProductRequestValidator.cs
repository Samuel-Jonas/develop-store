using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetById;

public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product id cannot be empty");
    }
}