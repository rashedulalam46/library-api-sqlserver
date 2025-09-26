using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Infrastructure;

public interface IBookRepository
{
    Task<Books> GetByIdAsync(int id);
    Task<IEnumerable<Books>> GetAllAsync();
    Task AddAsync(Books book);
    Task UpdateAsync(Books book);
    Task DeleteAsync(int id);
}