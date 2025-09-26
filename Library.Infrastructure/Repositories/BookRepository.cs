using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Books>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Books> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task AddAsync(Books book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Books book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}