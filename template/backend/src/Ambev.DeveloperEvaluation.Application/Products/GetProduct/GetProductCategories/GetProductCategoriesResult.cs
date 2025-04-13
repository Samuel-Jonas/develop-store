using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetProductCategories;

public class GetProductCategoriesResult
{
    public ProductCategory Category { get; set; }

    public GetProductCategoriesResult(ProductCategory category)
    {
        Category = category;
    }
}