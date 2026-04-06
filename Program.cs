using CountryDataWeaver.Data;
using Microsoft.EntityFrameworkCore;
using CountryDataWeaver.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=countries.db"));
builder.Services.AddHttpClient<CountryImportService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CountryDataWeaver API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
