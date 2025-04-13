using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartItemCommand : IRequest<CreateCartItemResult>
{
    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> Products { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartItemCommandValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };

    }
}