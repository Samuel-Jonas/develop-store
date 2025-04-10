using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartItemRepository
{
    Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default);
    
    Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<CartItem>> GetAllFromACartIdAsync(Guid cartId, CancellationToken cancellationToken = default);
    
    Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}