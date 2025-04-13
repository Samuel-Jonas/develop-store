using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetById;

public class GetProductByIdHandler : IRequestHandler<GetProductCommand, GetProductByIdResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<GetProductByIdResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return _mapper.Map<GetProductByIdResult>(product);
    }
}