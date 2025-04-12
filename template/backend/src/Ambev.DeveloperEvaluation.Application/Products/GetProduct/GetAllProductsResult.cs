using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetAllProductsResult
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductCategory Category { get; set; }

    public string Image { get; set; }

    public Rating Rating { get; set; }
    
}

public class Rating
{
    public decimal Rate { get; set; }

    public int Count { get; set; }
}