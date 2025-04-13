using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        
        CreateMap<(CreateProductRequest request, CreateProductResult result), CreateProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.result.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.request.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.request.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.request.Price))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.request.Image))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.request.Category))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.request.Rating));
        
        CreateMap<Common.ProductRating, 
            Ambev.DeveloperEvaluation.Application.Products.Common.ProductRating>();
    }
}