using Library.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api;

[ApiController]
[Route("api/[controller]")]
public class DropdownController : ControllerBase
{
    private readonly DropdownService _dropdownService;

    public DropdownController(DropdownService dropdownService)
    {
        _dropdownService = dropdownService;
    }

    // GET: api/dropdown/countries
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _dropdownService.GetCountryDropdownAsync();
        return Ok(countries); 
    }
}