using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductCategory Category { get; set; }

    public string ImageUrl { get; set; }

    public decimal Rate { get; set; }

    public int Count { get; set; }

    public Guid CreatedBy { get; set; }
    public User Creator { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public CartItem Item { get; set; }
    
    private Product() { }
}