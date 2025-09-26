using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class AuthorService
{
    private readonly IAuthorRepository _repo;
    public AuthorService(IAuthorRepository repo) => _repo = repo;

    public Task<IEnumerable<Authors>> GetAuthorsAsync() => _repo.GetAllAsync();
    public Task<Authors?> GetAuthorAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Authors> AddAuthorAsync(Authors author) => _repo.AddAsync(author);
    public Task<Authors?> UpdateAuthorAsync(Authors author) => _repo.UpdateAsync(author);
    public Task<bool> DeleteAuthorAsync(int id) => _repo.DeleteAsync(id);
}