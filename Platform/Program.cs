// Running with ngrok
// > ngrok http http://localhost:5246
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Platform.Models.Contexts;
using Platform.Models.Repositories;
using Platform.Models.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("DatabaseContextConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DatabaseContextConnection' not found."
    );

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Dependency injection
builder.Services.AddScoped<IMealTypeRepository, MealTypeRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<ISitemapRepository, SitemapRepository>();

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

app.MapControllers();
app.Run();
