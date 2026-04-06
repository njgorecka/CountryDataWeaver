using CountryDataWeaver.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryDataWeaver.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Country> Countries => Set<Country>();
}