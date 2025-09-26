using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Categories>> GetAllAsync();
    Task<Categories> GetByIdAsync(int id);
    Task AddAsync(Categories category);
    Task UpdateAsync(Categories category);
    Task DeleteAsync(int id);
}