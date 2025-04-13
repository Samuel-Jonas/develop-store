using Ambev.DeveloperEvaluation.Application.Carts.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartResult
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string Date { get; set; }

    public List<ProductCart> Products { get; set; }
}