using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 //── Entity Framework Core ──
builder.Services.AddDbContext<MyVaccineAppDbContext>(options =>
    options.UseSqlServer("Server=localhost,14330;Database=MyVaccineAppDb;User Id=sa;Password=Abc.123456;TrustServerCertificate=true;"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
