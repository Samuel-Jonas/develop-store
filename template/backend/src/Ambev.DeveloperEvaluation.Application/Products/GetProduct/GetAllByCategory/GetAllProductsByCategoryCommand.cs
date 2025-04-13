using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryCommand : IRequest<List<GetAllProductsByCategoryResult>>
{
    public ProductCategory Category { get; set; }
    
    public int Page { get; set; } = 1;
    
    public int Size { get; set; } = 10;
    
    public string? OrderBy { get; set; }

    public GetAllProductsByCategoryCommand(ProductCategory category)
    {
        Category = category;
    }
}