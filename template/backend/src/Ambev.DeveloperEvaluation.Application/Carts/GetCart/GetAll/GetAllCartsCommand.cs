using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;

public class GetAllCartsCommand : IRequest<List<GetAllCartsResult>>
{
    public int Page { get; set; }

    public int Size { get; set; }

    public string? OrderBy { get; set; }

    public GetAllCartsCommand(int page, int size, string orderBy)
    {
        Page = page;
        Size = size;
        OrderBy = orderBy;
    }
}