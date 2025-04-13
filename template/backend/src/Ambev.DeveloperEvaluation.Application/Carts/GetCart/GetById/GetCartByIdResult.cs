using Ambev.DeveloperEvaluation.Application.Carts.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;

public class GetCartByIdResult
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> Products { get; set; } = new List<ProductCart>();
}