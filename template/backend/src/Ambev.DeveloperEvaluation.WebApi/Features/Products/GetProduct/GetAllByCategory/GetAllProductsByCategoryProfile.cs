using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryProfile : Profile
{
    public GetAllProductsByCategoryProfile()
    {
        CreateMap<GetAllProductsByCategoryRequest, GetAllProductsByCategoryCommand>();

        CreateMap<GetAllProductsByCategoryResult, GetAllProductsByCategoryResponse>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.Rating.Count));
    }
}