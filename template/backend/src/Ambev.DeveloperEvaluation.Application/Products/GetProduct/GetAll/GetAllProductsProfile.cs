using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAll;

public class GetAllProductsProfile : Profile
{
    public GetAllProductsProfile()
    {
        CreateMap<Product, GetAllProductsResult>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom((src => src.Rate)))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom((src => src.Count)))
            .ForPath(dest => dest.Image, opt => opt.MapFrom((src => src.ImageUrl)));
    }
}