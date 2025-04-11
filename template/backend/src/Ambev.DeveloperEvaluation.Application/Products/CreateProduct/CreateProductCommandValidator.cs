using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(product => product.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(product => product.Price).NotEmpty().WithMessage("Price is required.");
        RuleFor(product => product.Rating.Rate).NotEmpty().WithMessage("Rate is required.");
        RuleFor(product => product.Rating.Count).NotEmpty().WithMessage("Count is required.");
        RuleFor(product => product.Image).NotEmpty().WithMessage("Image is required.");
    }
}