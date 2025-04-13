using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetAll;

public class GetAllCartsResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public List<ProductCart> Products { get; set; }
    
}