using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetAllProductCommand : IRequest<List<GetAllProductsResult>>
{
    public int Page { get; set; }

    public int Size { get; set; }

    public string? OrderBy { get; set; }

    public GetAllProductCommand(int page, int size, string orderBy)
    {
        Page = page;
        Size = size;
        OrderBy = orderBy;
    }
}