using Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetAll;

public class GetAllCartsProfile : Profile
{
    public GetAllCartsProfile()
    {
        CreateMap<GetAllCartsQueryParamRequest, GetAllCartsCommand>();
        
        CreateMap<GetAllCartsResult, GetAllCartsResponse>();
        CreateMap<Application.Carts.Common.ProductCart, ProductCart>();
    }
}