using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetAll;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart.GetById;
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

    //TODO: Checked (200 Ok) / Missing (400 BadRequest)
    // TODO: [Authorize] GetAllCarts
    //  TODO: GetAllCart pagination
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllCartsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCarts([FromQuery] GetAllCartsQueryParamRequest pagination,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllCartsCommand>(pagination);
        var response = await _mediator.Send(command, cancellationToken);

        var carts = _mapper.Map<List<GetAllCartsResponse>>(response);

        return OkPaginated(
            new PaginatedList<GetAllCartsResponse>(carts, carts.Count, pagination.Page, pagination.Size));
    }

    //TODO: Checked (200 Ok) / Missing (400 BadRequest, 404 NotFound)
    // TODO: [Authorize] GetCartById
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartByIdRequest { Id = id };
        var validator = new GetCartByIdRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<GetCartByIdCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);
        
        return Ok(_mapper.Map<GetCartByIdResponse>(response));
    }

    //TODO: Checked (201 Created) / Missing (400 BadRequest)
    // TODO: [Authorize] CreateCartItem
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<CreateCartItemCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<CreateCartItemResponse>(result);

        return Created(GetFullUri(), new ApiResponseWithData<CreateCartItemResponse>
        {
            Success = true,
            Message = "Cart created successfully.",
            Data = response
        });
    }

    //TODO: Checked (200 Ok) / Missing (400 BadRequest, 404 NotFound)
    // TODO: [Authorize] UpdateCartById
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartRequest>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCartById([FromRoute] Guid id,
        [FromBody] UpdateCartRequest request,
        CancellationToken cancellationToken)
    {
        UpdateCartRequestValidator validator = new UpdateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<UpdateCartCommand>((id, request));
        
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<UpdateCartResponse>(result);
        
        return Ok(response);
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