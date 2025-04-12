using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductRequest, CreateProductResponse>();
        CreateMap<CreateProductResult, CreateProductResponse>();
        
        CreateMap<ProductRating, Ambev.DeveloperEvaluation.Application.Products.CreateProduct.ProductRating>();
    }
}