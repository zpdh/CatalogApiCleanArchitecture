using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Category>> GetAllAsync()
    {
            return await _context.Categories.ToListAsync();
    }
    public async Task<Category> GetEntityByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Category> UpdateAsync(Category entity)
    {
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Category> RemoveAsync(Category entity)
    {
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}