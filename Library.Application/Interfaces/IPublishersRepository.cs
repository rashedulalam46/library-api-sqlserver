using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IPublishersRepository
{
    Task<Publishers> GetByIdAsync(int id);
    Task<IEnumerable<Publishers>> GetAllAsync();
    Task AddAsync(Publishers publisher);
    Task UpdateAsync(Publishers publisher);
    Task DeleteAsync(int id);
}