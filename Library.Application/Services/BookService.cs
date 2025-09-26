using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class BookService
{
    private readonly IBookRepository _repo;
    public BookService(IBookRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Books>> GetBooksAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Books?> GetBookAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public Task<Books> AddBookAsync(Books book)
    {
        return _repo.AddAsync(book);
    }
    public Task<Books?> UpdateBookAsync(Books book)
    {
        return _repo.UpdateAsync(book);
    }
    public Task<bool> DeleteBookAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}

