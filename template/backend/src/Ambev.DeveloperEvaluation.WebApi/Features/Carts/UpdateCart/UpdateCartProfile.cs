using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<(Guid id, UpdateCartRequest cartRequest), UpdateCartCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.cartRequest.Date))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.cartRequest.UserId))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.cartRequest.Products));

        CreateMap<UpdateCartResult, UpdateCartResponse>();
        
        CreateMap<Ambev.DeveloperEvaluation.Application.Carts.Common.ProductCart, Common.ProductCart>();

    }
}