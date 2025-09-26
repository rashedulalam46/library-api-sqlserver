using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class PublishersService
{
    private readonly IPublishersRepository _repo;
    public PublishersService(IPublishersRepository repo) => _repo = repo;

    public Task<IEnumerable<Publishers>> GetPublishersAsync() => _repo.GetAllAsync();
    public Task<Publishers?> GetPublisherAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Publishers> AddPublisherAsync(Publishers publisher) => _repo.AddAsync(publisher);
    public Task<Publishers?> UpdatePublisherAsync(Publishers publisher) => _repo.UpdateAsync(publisher);
    public Task<bool> DeletePublisherAsync(int id) => _repo.DeleteAsync(id);
}