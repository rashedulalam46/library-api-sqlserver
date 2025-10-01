
using Library.Application.DTOs;
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

        public async Task<IEnumerable<BookReadDto>> GetAllAsync()
        {
            var query = from b in _context.Books
                        join a in _context.Authors
                            on b.author_id equals a.author_id
                        join c in _context.Categories
                            on b.category_id equals c.category_id
                        join p in _context.Publishers
                            on b.publisher_id equals p.publisher_id
                        select new BookReadDto
                        {
                            BookId = b.book_id,
                            Title = b.title,
                            Description = b.description,
                            AuthorName = a.author_name,
                            CategoryName = c.category_name,
                            PublisherName = p.publisher_name,
                            ISBN = b.ISBN,
                            Price = b.price,
                            Active = b.active,
                            PublishDate = b.publish_date
                        };

            return await query.ToListAsync();
        }


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
        public async Task<bool> ExistsByBookIdAsync(int bookId)
        {
            return await _context.Books.AnyAsync(a => a.book_id == bookId);
        }
    }
}
