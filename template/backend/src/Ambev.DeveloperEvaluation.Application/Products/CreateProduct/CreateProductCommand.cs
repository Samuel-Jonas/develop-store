using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductResult>
{

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductCategory Category { get; set; }

    public string Image { get; set; }

    public ProductRating Rating { get; set; }

    public string LoggedUserEmail { get; set; }
    
    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductCommandValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}