using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    
    private readonly DefaultContext _context;

    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return product;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Where(p => p.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = await _context.Products
            .AsTracking()
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == product.Id, cancellationToken);

        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }

        if (existingProduct.Category != product.Category)
        {
            existingProduct.Category = product.Category;
        }

        if (existingProduct.Price != product.Price)
        {
            existingProduct.Price = product.Price;
        }

        if (existingProduct.Rate != product.Rate)
        {
            existingProduct.Rate = product.Rate;
        }

        if (existingProduct.Count != product.Count)
        {
            existingProduct.Count = product.Count;
        }

        if (existingProduct.Description != product.Description)
        {
            existingProduct.Description = product.Description;
        }

        if (existingProduct.Title != product.Title)
        {
            existingProduct.Title = product.Title;
        }

        if (existingProduct.ImageUrl != product.ImageUrl)
        {
            existingProduct.ImageUrl = product.ImageUrl;
        }
        
        existingProduct.UpdatedAt = DateTime.Now;
            
        await _context.SaveChangesAsync(cancellationToken);
        return existingProduct;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Where(p => p.DeletedAt == null)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (product == null)
        {
            return false;
        }
        
        product.DeletedAt = DateTime.Now;
        product.UpdatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}