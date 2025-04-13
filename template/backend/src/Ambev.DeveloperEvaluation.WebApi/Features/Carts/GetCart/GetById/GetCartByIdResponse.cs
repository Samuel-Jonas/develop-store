using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetById;

public class GetCartByIdResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> products { get; set; }
    
}