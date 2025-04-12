using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/products")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        
        //TODO: Remove mocked user
        command.LoggedUserEmail = "customer@gmail.com"; //this.GetCurrentUserEmail();
        
        var response = await _mediator.Send(command, cancellationToken);
        _mapper.Map<CreateProductResponse>(request);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully.",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryParamsRequest pagination, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllProductCommand>(pagination);
        var response = await _mediator.Send(command, cancellationToken);

        var products = _mapper.Map<List<GetAllProductsResponse>>(response);

        return OkPaginated(new PaginatedList<GetAllProductsResponse>(products, products.Count, pagination.Page, pagination.Size));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };
        var validator = new GetProductRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<GetProductCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetAllProductsResponse>(response));
    }
    
    //TODO: Get all products by category
    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetAllProductsByCategory([FromRoute] ProductCategory category,
        [FromQuery] GetAllProductsQueryParamsRequest queryParams,
        CancellationToken cancellationToken)
    {
        var request = new GetAllProductsByCategoryRequest { Category = category };
        var validator = new GetAllProductsByCategoryRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<GetProductCommand>(request.Category);
        var response = await _mediator.Send(command, cancellationToken);
        
        return Ok(_mapper.Map<GetAllProductsResponse>(response));
    }
    
    //rai: Get all categories existing in database
    [HttpGet("categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<string>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsCategories(CancellationToken cancellationToken)
    {
        return Ok(new { });
    }

    //TODO: Delete product
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(new { });
    }
}