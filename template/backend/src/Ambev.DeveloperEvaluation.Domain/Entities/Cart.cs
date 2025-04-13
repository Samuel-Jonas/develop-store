using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; private set; }

    public DateTime? CheckedOutAt { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();
    
    private Cart() { }

    public void AddItem(Product product, int quantity, decimal price)
    {
        Items.Add(new CartItem(product.Id, this.Id, quantity, price));
    }

    public void AddRangeCartItems(ICollection<CartItem> cartItems)
    {
        foreach (CartItem cartItem in cartItems)
        {
            Items.Add(cartItem);
        }
    }

    public void Checkout()
    {
        this.CheckedOutAt = DateTime.Now;
    }
}