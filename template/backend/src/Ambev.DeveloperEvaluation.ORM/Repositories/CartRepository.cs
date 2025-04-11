using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return cart;
    }

    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Where(c => c.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Where(c => c.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Cart> UpdateCheckoutAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        var existingCart = await _context.Carts
            .Where(c => c.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == cart.Id, cancellationToken);

        if (existingCart == null)
        {
            throw new Exception("Cart not found");
        }
        
        existingCart.Checkout();
        existingCart.UpdatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync(cancellationToken);
        return existingCart;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts
            .Where(c => c.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (cart == null)
        {
            return false;
        }
        
        cart.DeletedAt = DateTime.Now;
        cart.UpdatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}