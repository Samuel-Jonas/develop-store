using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetById;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetById;

public class GetProductByIdProfile : Profile
{
    public GetProductByIdProfile()
    {
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));
        
        CreateMap<GetProductByIdResult, GetProductByIdResponse>()
            .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
            .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.Rating.Count));
    }
}