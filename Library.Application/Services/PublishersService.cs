using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class PublishersService
{
    private readonly IPublishersRepository _repo;
    public PublishersService(IPublishersRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Publishers>> GetPublishersAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Publishers?> GetPublisherAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public Task<Publishers> AddPublisherAsync(Publishers publisher)
    {
        return _repo.AddAsync(publisher);
    }
    public Task<Publishers?> UpdatePublisherAsync(Publishers publisher)
    {
        return _repo.UpdateAsync(publisher);
    }
    public Task<bool> DeletePublisherAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}