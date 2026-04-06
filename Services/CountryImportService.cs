using System.Text.Json;
using CountryDataWeaver.Models;
using CountryDataWeaver.Data;
using Microsoft.EntityFrameworkCore;

namespace CountryDataWeaver.Services;

public class CountryImportService
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public CountryImportService(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<int> ImportCountriesAsync()
    {
        var url = "https://restcountries.com/v3.1/all?fields=name,region,subregion,capital,population,area,flags";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var apiCountries = JsonSerializer.Deserialize<List<RestCountryApiResponse>>(json, options);

        if (apiCountries == null)
            return 0;

        int added = 0;

        foreach (var c in apiCountries)
        {
            var exists = await _context.Countries
                .AnyAsync(x => x.Name == c.Name.Common);

            if (exists)
                continue;

            var country = new Country
            {
                Name = c.Name.Common,
                OfficialName = c.Name.Official,
                Region = c.Region,
                Subregion = c.Subregion,
                Capital = c.Capital?.FirstOrDefault() ?? "",
                Population = c.Population,
                Area = c.Area,
                FlagPngUrl = c.Flags.Png,
                ImportedAt = DateTime.UtcNow
            };

            _context.Countries.Add(country);
            added++;
        }
        
        await _context.SaveChangesAsync();
        return added;
    }
}