using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryProfile : Profile
{
    public GetAllProductsByCategoryProfile()
    {
        CreateMap<Product, GetAllProductsByCategoryResult>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom((src => src.Rate)))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom((src => src.Count)))
            .ForPath(dest => dest.Image, opt => opt.MapFrom((src => src.ImageUrl)));
    }
}