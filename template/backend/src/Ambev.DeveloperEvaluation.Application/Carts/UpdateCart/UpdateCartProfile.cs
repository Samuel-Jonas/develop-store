using System.Globalization;
using Ambev.DeveloperEvaluation.Application.Carts.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartCommand, Cart>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Products.Select(x => new CartItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList()))
            .ForMember(dest => dest.CheckedOutAt, opt => opt.MapFrom(src => 
                src.Date == null
                ? (DateTime?) null
                : DateTime.ParseExact(src.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal))
            );
        
        CreateMap<Cart, UpdateCartResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items.Select(x => new ProductCart
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList()))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => 
                src.CheckedOutAt.HasValue
                ? src.CheckedOutAt.Value.ToString("yyyy-MM-dd")
                : null)
            );
    }
}