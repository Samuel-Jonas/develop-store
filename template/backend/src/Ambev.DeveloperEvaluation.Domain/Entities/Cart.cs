using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public DateTime CheckedOutAt { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();
    
    private Cart() { }

    public void AddItem(Product product, int quantity, decimal price)
    {
        Items.Add(new CartItem(product.Id.ToString(), this.Id.ToString(), quantity, price));
    }
}