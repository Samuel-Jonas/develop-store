using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);
    
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Cart>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<Cart> UpdateCheckoutAsync(Cart cart, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}