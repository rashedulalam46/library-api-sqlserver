using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    Task<Books?> GetByIdAsync(int id);
    Task<IEnumerable<Books>> GetAllAsync();
    Task<Books> AddAsync(Books book);
    Task<Books?> UpdateAsync(Books book);
    Task<bool> DeleteAsync(int id);
}