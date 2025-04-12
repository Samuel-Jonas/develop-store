using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetAllProductsProfile : Profile
{
    public GetAllProductsProfile()
    {
        CreateMap<Product, GetAllProductsResult>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom((src => src.Rate)))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom((src => src.Count)));
    }
}