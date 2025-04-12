using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetAllProductsByCategoryRequestValidator : AbstractValidator<GetAllProductsByCategoryRequest>
{
    public GetAllProductsByCategoryRequestValidator()
    {
        RuleFor(x => x.Category)
            .NotNull()
            .NotEmpty()
            .WithMessage("The category cannot be null or empty.");
        
        RuleFor(x => x.Category)
            .IsInEnum()
            .WithMessage("Invalid category");
    }
}