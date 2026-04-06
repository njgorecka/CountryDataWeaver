using CountryDataWeaver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountryDataWeaver.Services;

namespace CountryDataWeaver.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly CountryImportService _importService;

    public CountriesController(AppDbContext context, CountryImportService importService)
    {
        _context = context;
        _importService = importService;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("Countries API is working.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countries = await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();

        return Ok(countries);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import()
    {
        var added = await _importService.ImportCountriesAsync();
        return Ok(new { added });
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Name is required.");
        }

        var results = await _context.Countries
            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
            .OrderBy(c => c.Name)
            .ToListAsync();

        return Ok(results);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> Stats()
    {
        var total = await _context.Countries.CountAsync();
        
        var regions = await _context.Countries
            .Select(c => c.Region)
            .Where(r => !string.IsNullOrEmpty(r))
            .Distinct()
            .CountAsync();

        var biggest = await _context.Countries
            .OrderByDescending(c => c.Population)
            .Select(c => new
            {
                c.Name,
                c.Population
            })
            .FirstOrDefaultAsync();
        
        return Ok(new
        {
            totalCountries = total,
            uniqueRegions = regions,
            mostPopulated = biggest
        });
    }

}