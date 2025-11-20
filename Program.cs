using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.EF.Api.EFContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(x => x.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.Run();
