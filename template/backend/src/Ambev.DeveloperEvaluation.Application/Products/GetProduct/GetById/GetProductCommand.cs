using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetById;

public class GetProductCommand : IRequest<GetProductByIdResult>
{
    public Guid Id { get; set; }

    public GetProductCommand(Guid id)
    {
        Id = id;
    }
    
}