using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartItemResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> products { get; set; }
    
}