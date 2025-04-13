using Ambev.DeveloperEvaluation.Domain.Enums;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetProductCategories;

public class GetProductCategoriesProfile : Profile
{
    public GetProductCategoriesProfile()
    {
        CreateMap<Object, GetProductCategoriesCommand>();
        
        CreateMap<ProductCategory, GetProductCategoriesResult>()
            .ConstructUsing(category => new GetProductCategoriesResult(category));
    }
}