using Ambev.DeveloperEvaluation.Application.Carts.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartItemResult
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> Products { get; set; }

    public ICollection<ProductCart> NotFoundProducts { get; set; }
}