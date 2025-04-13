using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct.GetProductCategories;

public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesCommand, List<GetProductCategoriesResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductCategoriesHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetProductCategoriesResult>> Handle(GetProductCategoriesCommand request, CancellationToken cancellationToken)
    {
        List<ProductCategory> categories = await _productRepository.GetAllProductCategoriesAsync(cancellationToken);
        
        return _mapper.Map<List<GetProductCategoriesResult>>(categories);
    }
}