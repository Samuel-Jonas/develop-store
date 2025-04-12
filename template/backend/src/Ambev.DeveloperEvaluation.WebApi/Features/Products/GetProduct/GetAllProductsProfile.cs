using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetAllProductsProfile : Profile
{
    public GetAllProductsProfile()
    {
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));
        
        CreateMap<ProductCategory, GetProductCommand>()
            .ConstructUsing(category => new GetProductCommand(category));
        
        CreateMap<GetAllProductsQueryParamsRequest, GetAllProductCommand>();
        CreateMap<GetAllProductsResult, GetAllProductsResponse>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.Rating.Count));
    }
}