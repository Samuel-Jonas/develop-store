using Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetById;

public class GetCartByIdProfile : Profile
{
    public GetCartByIdProfile()
    {
        CreateMap<Guid, GetCartByIdCommand>()
            .ConstructUsing(id => new GetCartByIdCommand(id));
        
        CreateMap<GetCartByIdResult, GetCartByIdResponse>();
    }
}