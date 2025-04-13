using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetProductCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetProductCategories;

public class GetProductCategoriesProfile : Profile
{
    public GetProductCategoriesProfile()
    {
        CreateMap<GetProductCategoriesResult, GetProductCategoriesResponse>();
    }
}