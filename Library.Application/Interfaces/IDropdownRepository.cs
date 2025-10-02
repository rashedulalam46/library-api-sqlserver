using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IDropdownRepository
{
    // Define methods for dropdown data retrieval, e.g.:
    Task<IEnumerable<DropdownItem>> GetCountryDropdownAsync();
}