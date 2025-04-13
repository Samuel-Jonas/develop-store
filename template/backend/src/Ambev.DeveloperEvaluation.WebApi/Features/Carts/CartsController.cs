using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/carts")]
public class CartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //TODO: Get all existing carts
    // TODO: [Authorize] GetAllCarts
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllCartsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCarts([FromQuery] GetAllCartsQueryParamRequest pagination, CancellationToken cancellationToken)
    {
        return Ok(new { });
    }

    //TODO: Create a cart if not exists and add the item to cart
    // TODO: [Authorize] CreateCartItem
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemRequest request, CancellationToken cancellationToken)
    {
        return Ok(new { });
    }

    //TODO: Get cart using the cart id
    // TODO: [Authorize] GetCartById
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(new { });
    }

    //TODO: Update cart using the cart id and request body
    // TODO: [Authorize] UpdateCartById
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartRequest>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCartById([FromRoute] Guid id,
        [FromBody] UpdateCartRequest request, 
        CancellationToken cancellationToken)
    {
        return Ok(new { });
    }

    //TODO: Delete cart using the cart id
    // TODO: [Authorize] DeleteCartById
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCartById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(new { });
    }
}