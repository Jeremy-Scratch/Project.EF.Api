using Microsoft.EntityFrameworkCore;
using Project.EF.Api.Models;

namespace Project.EF.Api.EFContext;
public class TareasContext: DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}
}