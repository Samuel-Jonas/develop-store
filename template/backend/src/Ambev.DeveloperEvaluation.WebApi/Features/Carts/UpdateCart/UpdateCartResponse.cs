using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public ICollection<ProductCart> products { get; set; }
}