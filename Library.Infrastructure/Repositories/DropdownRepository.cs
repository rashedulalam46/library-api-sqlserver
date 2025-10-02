using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Application.DTOs;

namespace Library.Infrastructure.Repositories;

public class DropdownRepository : IDropdownRepository
{
    private readonly LibraryDbContext _context;

    public DropdownRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DropdownItem>> GetCountryDropdownAsync()
    {
        return await _context.Countries
            .Select(c => new DropdownItem
            {
                Value = c.country_id.ToString(),
                Text = c.country_name
            })
            .ToListAsync();
    }
}