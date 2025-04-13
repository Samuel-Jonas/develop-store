using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartCommand : IRequest<UpdateCartResult>
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string? Date { get; set; }

    public List<ProductCart> Products { get; set; }

    public ValidationResultDetail Validate()
    {
        var validation = new UpdateCartCommandValidator();
        var result = validation.Validate(this);
        
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}