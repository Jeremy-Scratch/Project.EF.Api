using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.EF.Api.EFContext;
using Project.EF.Api.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(x => x.UseInMemoryDatabase("TareasDB"));
var connectionString = builder.Configuration.GetConnectionString("cnTareas");
builder.Services.AddNpgsql<TareasContext>(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(x => x.Category));

});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid Id) =>
{
    var tareaToUpdate = dbContext.Tareas.Find(Id);

    if (tareaToUpdate != null)
    {
        tareaToUpdate.CategoryId = tarea.CategoryId;
        tareaToUpdate.Title = tarea.Title;
        tareaToUpdate.TareaPriority = tarea.TareaPriority;
        tareaToUpdate.Description = tarea.Description;

        await dbContext.SaveChangesAsync();
        return Results.Ok(); 
    }

    return Results.NotFound();
});

app.Run();
