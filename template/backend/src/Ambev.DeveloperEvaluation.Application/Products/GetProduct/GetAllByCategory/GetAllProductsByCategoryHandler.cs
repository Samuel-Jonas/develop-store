using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetAllByCategory;

public class GetAllProductsByCategoryHandler : IRequestHandler<GetAllProductsByCategoryCommand, List<GetAllProductsByCategoryResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsByCategoryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetAllProductsByCategoryResult>> Handle(GetAllProductsByCategoryCommand request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetAllProductsByCategoryAsync(request.Category, cancellationToken);
        
        return _mapper.Map<List<GetAllProductsByCategoryResult>>(products);
    }
}