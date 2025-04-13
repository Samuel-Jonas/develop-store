using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductCategory Category { get; set; }

    public string Image { get; set; }

    public ProductRating Rating { get; set; }
}