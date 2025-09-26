
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class BookRepository : IBookRepository
    {     
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        

        public async Task<IEnumerable<Books>> GetAllAsync() =>
            await _context.Books.ToListAsync();

        public async Task<Books?> GetByIdAsync(int id) =>
            await _context.Books.FindAsync(id);

        public async Task<Books> AddAsync(Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Books?> UpdateAsync(Books book)
        {
            var existing = await _context.Books.FindAsync(book.book_id);
            if (existing == null) return null;

            existing.title = book.title;
            existing.author_id = book.author_id;
            existing.category_id = book.category_id;
            existing.publisher_id = book.publisher_id;
            existing.publish_date = book.publish_date;
            existing.ISBN = book.ISBN;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
