using Ambev.DeveloperEvaluation.Application.Carts.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;

public class GetAllCartsResult
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Date { get; set; }

    public List<ProductCart> Products { get; set; }
}