using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAll;

public class GetAllProductsQueryParamsRequest
{
    [FromQuery(Name = "_page")]
    public int Page { get; set; } = 1;

    [FromQuery(Name = "_size")]
    public int Size { get; set; } = 10;

    [FromQuery(Name = "_order")]
    public string? OrderBy { get; set; }
}