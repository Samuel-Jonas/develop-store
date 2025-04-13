using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;

public class GetCartByIdProfile : Profile
{
    public GetCartByIdProfile()
    {
        CreateMap<Cart, GetCartByIdResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items.Select(x => new ProductCart
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList()))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CheckedOutAt.HasValue ? src.CheckedOutAt.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : "null"));
    }
}