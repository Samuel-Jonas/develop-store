using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;

public class GetCartByIdCommand : IRequest<GetCartByIdResult>
{
    public Guid Id { get; set; }

    public GetCartByIdCommand(Guid id)
    {
        Id = id;
    }
}