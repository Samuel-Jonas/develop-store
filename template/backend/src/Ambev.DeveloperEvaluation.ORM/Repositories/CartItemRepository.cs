using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly DefaultContext _context;

    public CartItemRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        await _context.CartItems.AddAsync(cartItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return cartItem;
    }

    public async Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.CartItems
            .Where(c => c.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<CartItem>> GetAllFromACartIdAsync(Guid cartId, CancellationToken cancellationToken = default)
    {
        return await _context.CartItems
            .Where(ci => ci.CartId == cartId && ci.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
    {
        var existingCartItem = await _context.CartItems
            .AsTracking()
            .Where(ci => ci.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == cartItem.Id, cancellationToken);

        if (existingCartItem == null)
        {
            throw new Exception("CartItem not found");
        }

        if (existingCartItem.Quantity != cartItem.Quantity)
        {
            existingCartItem.Quantity = cartItem.Quantity;
        }

        if (existingCartItem.PriceAtAddition != cartItem.PriceAtAddition)
        {
            existingCartItem.PriceAtAddition = cartItem.PriceAtAddition;
        }

        if (existingCartItem.ProductId != cartItem.ProductId)
        {
            existingCartItem.ProductId = cartItem.ProductId;
        }
        
        existingCartItem.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync(cancellationToken);
        return existingCartItem;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cartItem = await _context.CartItems
            .Where(ci => ci.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (cartItem == null)
        {
            return false;
        }
        
        cartItem.DeletedAt = DateTime.UtcNow;
        cartItem.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}