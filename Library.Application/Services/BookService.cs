using Library.Infrastructure;
using Library.Domain;
namespace Library.Services;

public class BookService
{
    private readonly IBookRepository _repo;
    public BookService(IBookRepository repo) => _repo = repo;

    public Task<IEnumerable<Books>> GetBooksAsync() => _repo.GetAllAsync();
    public Task<Books?> GetBookAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Books> AddBookAsync(Books book) => _repo.AddAsync(book);
    public Task<Books?> UpdateBookAsync(Books book) => _repo.UpdateAsync(book);
    public Task<bool> DeleteBookAsync(int id) => _repo.DeleteAsync(id);
}
