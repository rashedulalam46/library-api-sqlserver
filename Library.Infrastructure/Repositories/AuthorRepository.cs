using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _context;

    public AuthorRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Authors>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Authors> GetByIdAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task AddAsync(Authors author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Authors author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}