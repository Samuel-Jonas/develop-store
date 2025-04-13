using Ambev.DeveloperEvaluation.Application.Products.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryResult
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductCategory Category { get; set; }

    public string Image { get; set; }

    public ProductRating Rating { get; set; }
}