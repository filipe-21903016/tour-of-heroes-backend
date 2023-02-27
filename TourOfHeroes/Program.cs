using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TourOfHeroes.Models;
using TourOfHeroes.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TourOfHeroesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TourOfHeroesDbConnection"));
});

builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddTransient<TeaPotMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//teapot here
app.UseTeapotMiddleware();

app.MapControllers();

app.Run();
