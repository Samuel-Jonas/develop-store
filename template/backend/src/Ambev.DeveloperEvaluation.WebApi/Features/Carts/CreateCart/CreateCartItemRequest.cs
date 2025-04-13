using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartItemRequest
{
    public Guid UserId { get; set; }

    public string Date { get; set; }

    public IQueryable<ProductCart> Products { get; set; }
    
}