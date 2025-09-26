using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IAuthorRepository
{
    Task<Authors> GetByIdAsync(int id);
    Task<IEnumerable<Authors>> GetAllAsync();
    Task AddAsync(Authors author);
    Task UpdateAsync(Authors author);
    Task DeleteAsync(int id);
}