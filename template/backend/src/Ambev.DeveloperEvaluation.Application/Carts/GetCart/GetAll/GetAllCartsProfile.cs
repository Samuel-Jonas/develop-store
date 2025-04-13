using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;

public class GetAllCartsProfile : Profile
{
    public GetAllCartsProfile()
    {
        CreateMap<Cart, GetAllCartsResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CheckedOutAt.HasValue 
                ? src.CheckedOutAt.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                : null))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items.Select(i => new ProductCart
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
            })));
    }
}