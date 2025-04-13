using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductCommand, Product>()
            .ForPath(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
            .ForPath(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
            .ForPath(dest => dest.Count, opt => opt.MapFrom(src => src.Rating.Count));

        CreateMap<Product, UpdateProductResult>()
            .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl))
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.Rate))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.Count));
    }
}