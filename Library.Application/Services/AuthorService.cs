using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class AuthorService
{
    private readonly IAuthorRepository _repo;
    public AuthorService(IAuthorRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Authors>> GetAuthorsAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Authors?> GetAuthorAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public Task<Authors> AddAuthorAsync(Authors author)
    {
        return _repo.AddAsync(author);
    }
    public Task<Authors?> UpdateAuthorAsync(Authors author)
    {
        return _repo.UpdateAsync(author);
    }
    public Task<bool> DeleteAuthorAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}