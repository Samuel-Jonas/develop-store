using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartItemProfile : Profile
{
    public CreateCartItemProfile()
    {
        CreateMap<CreateCartItemRequest, CreateCartItemCommand>();

        CreateMap<CreateCartItemResult, CreateCartItemResponse>();

        CreateMap<Common.ProductCart, Ambev.DeveloperEvaluation.Application.Carts.Common.ProductCart>();
    }
}