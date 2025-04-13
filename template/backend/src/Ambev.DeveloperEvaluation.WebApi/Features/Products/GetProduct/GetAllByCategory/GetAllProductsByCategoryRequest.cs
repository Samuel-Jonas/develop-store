using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryRequest
{
    public ProductCategory Category { get; set; }
    
    public int Page { get; set; } = 1;
    
    public int Size { get; set; } = 10;
    
    public string? OrderBy { get; set; }
}