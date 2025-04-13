using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartItemProfile : Profile
{
    public CreateCartItemProfile()
    {
        CreateMap<CreateCartItemCommand, Cart>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
                src.Products.Select(x => new CartItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                }).ToList()));
        
        CreateMap<(Cart cart, List<CartItem> notFoundItems), CreateCartItemResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.cart.Id))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.cart.CheckedOutAt))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.cart.UserId))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.cart.Items.Select(x => new ProductCart
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()))
            .ForMember(dest => dest.NotFoundProducts, opt => opt.MapFrom(src => src.notFoundItems.Select(x => new ProductCart
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            })));
    }
}