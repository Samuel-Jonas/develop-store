using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequest
{
    public Guid UserId { get; set; }

    public string? Date { get; set; }

    public List<ProductCart> Products { get; set; }
}