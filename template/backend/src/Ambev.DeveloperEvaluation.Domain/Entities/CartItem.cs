using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; private set; }

    public Guid CartId { get; set; }
    public Cart Cart { get; set; }

    public int Quantity { get; set; }

    public decimal PriceAtAddition { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    private CartItem() { }

    public CartItem(Guid productId, Guid cartId, int quantity, decimal priceAtAddition)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        CartId = cartId;
        Quantity = quantity;
        PriceAtAddition = priceAtAddition;
    }
}