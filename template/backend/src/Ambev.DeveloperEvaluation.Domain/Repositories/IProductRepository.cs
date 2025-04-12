using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{ 
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    
    Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category, CancellationToken cancellationToken = default);
    
    Task<List<ProductCategory>> GetAllProductCategoriesAsync(CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}