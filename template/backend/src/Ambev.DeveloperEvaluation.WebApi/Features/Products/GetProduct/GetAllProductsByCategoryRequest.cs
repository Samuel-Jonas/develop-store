using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetAllProductsByCategoryRequest
{
    public ProductCategory Category { get; set; }
}