using Microsoft.EntityFrameworkCore;
using Project.EF.Api.Models;

namespace Project.EF.Api.EFContext;
public class TareasContext: DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(x => x.CategoryId);
            category.Property(x => x.Name).IsRequired().HasMaxLength(150);
            category.Property(x => x.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Task");
            tarea.HasKey(x => x.TareaId);
            tarea.Property(x => x.Title).IsRequired().HasMaxLength(150);
            tarea.Property(x => x.Description).HasMaxLength(200);
            tarea.Ignore(x=>x.Resume);
        });
    }
}