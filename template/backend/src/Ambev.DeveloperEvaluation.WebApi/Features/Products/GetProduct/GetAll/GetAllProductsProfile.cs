using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAll;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAll;

public class GetAllProductsProfile : Profile
{
    public GetAllProductsProfile()
    {
        CreateMap<GetAllProductsQueryParamsRequest, GetAllProductCommand>();
        CreateMap<GetAllProductsResult, GetAllProductsResponse>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.Rating.Count));
    }
}