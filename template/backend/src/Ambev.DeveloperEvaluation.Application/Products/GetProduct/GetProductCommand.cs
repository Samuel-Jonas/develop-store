using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductCommand : IRequest<GetAllProductsResult>
{
    public Guid Id { get; set; }

    public ProductCategory Category { get; set; }

    public GetProductCommand(Guid id)
    {
        Id = id;
    }

    public GetProductCommand(ProductCategory category)
    {
        Category = category;
    }
}