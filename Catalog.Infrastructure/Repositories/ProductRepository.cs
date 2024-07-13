using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetEntityByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product> RemoveAsync(Product entity)
    {
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}