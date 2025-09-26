using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class PublishersRepository : IPublishersRepository
{
    private readonly LibraryDbContext _context;

    public PublishersRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Publishers>> GetAllAsync()
    {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<Publishers> GetByIdAsync(int id)
    {
        return await _context.Publishers.FindAsync(id);
    }

    public async Task AddAsync(Publishers publisher)
    {
        await _context.Publishers.AddAsync(publisher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Publishers publisher)
    {
        _context.Publishers.Update(publisher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}