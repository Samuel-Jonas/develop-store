using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly DefaultContext _context;

    public CartItemRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CartItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<CartItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}