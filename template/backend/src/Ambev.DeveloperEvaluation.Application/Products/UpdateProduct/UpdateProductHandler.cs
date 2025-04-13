using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validation = new UpdateProductCommandValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        Product product = _mapper.Map<Product>(request);
        
        Product updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);
        var result = _mapper.Map<UpdateProductResult>(updatedProduct);
        
        return result;
    }
}