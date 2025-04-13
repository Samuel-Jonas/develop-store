using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAll;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetById;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetProductCategories;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAll;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetAllByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetById;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct.GetProductCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    //TODO: Checked (Created 201) / Missing (BadRequest 400)
    // TODO: [Authorize] CreateProduct
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
        
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<CreateProductResponse>((request, result));

        return Created(GetFullUri(), new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully.",
            Data = response
        });
    }
    
    //TODO: Checked (OK 200) / Missing (BadRequest 400)
    // TODO: [Authorize] GetAllProducts
    //  TODO: GetAllProducts pagination
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

    //TODO: Checked (OK 200) / Missing (BadRequest 400, NotFound 404)
    // TODO: [Authorize] GetProductById
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetProductByIdResponse), StatusCodes.Status200OK)]
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

        return Ok(_mapper.Map<GetProductByIdResponse>(response));
    }
    
    //TODO: Checked (Ok 200) / Missing (BadRequest 400)
    // TODO: [Authorize] GetAllProductsByCategory
    //  TODO: GetAllProductsByCategory pagination
    [HttpGet("category/{category}")]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllProductsByCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProductsByCategory([FromRoute] ProductCategory category,
        [FromQuery] GetAllProductsQueryParamsRequest pagination,
        CancellationToken cancellationToken)
    {
        GetAllProductsByCategoryRequest request = new GetAllProductsByCategoryRequest
        {
            Category = category, 
            Page = pagination.Page, 
            Size = pagination.Size, 
            OrderBy = pagination.OrderBy
        };
        
        var validator = new GetAllProductsByCategoryRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<GetAllProductsByCategoryCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        var products = _mapper.Map<List<GetAllProductsByCategoryResponse>>(response);

        return OkPaginated(new PaginatedList<GetAllProductsByCategoryResponse>(products, products.Count, pagination.Page, pagination.Size));
    }
    
    [HttpGet("categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<string>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsCategories(CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetProductCategoriesCommand>(new object());
        var response = await _mediator.Send(command, cancellationToken);
        
        var productCategories = _mapper.Map<List<GetProductCategoriesResponse>>(response);
        
        List<string> categories = productCategories.Select(c => c.Category.GetDisplayName()).ToList();
        
        return Ok(categories);
    }

    //TODO: Checked (Ok 200) Missing (BadRequest 400)
    // TODO: [Authorize] DeleteProductById
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeleteProductRequest request = new DeleteProductRequest { Id = id} ;
        DeleteProductRequestValidator validator = new DeleteProductRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<DeleteProductCommand>(request.Id);
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(new ApiResponse
        {
            Success = result.Success,
            Message = "Product deleted successfully.",
        });
    }

    //TODO: Checked (Ok 200) Missing (BadRequest 400, NotFound 404)
    // TODO: [Authorize] UpdateProductById
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProductById([FromRoute] Guid id, 
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        UpdateProductRequestValidator validator = new UpdateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<UpdateProductCommand>((id, request));
        
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<UpdateProductResponse>(result);
        
        return Ok(response);
    }
}