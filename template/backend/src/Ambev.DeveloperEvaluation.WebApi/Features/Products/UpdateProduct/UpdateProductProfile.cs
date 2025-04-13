using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<(Guid id, UpdateProductRequest request), UpdateProductCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.request.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.request.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.request.Price))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.request.Image))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.request.Category))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.request.Rating));

        CreateMap<UpdateProductResult, UpdateProductResponse>();
        
        CreateMap<Ambev.DeveloperEvaluation.Application.Products.Common.ProductRating,
            Common.ProductRating>();
    }
}