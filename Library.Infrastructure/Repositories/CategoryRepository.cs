using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryDbContext _context;

    public CategoryRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Categories> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Categories category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Categories category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}