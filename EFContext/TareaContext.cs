using Microsoft.EntityFrameworkCore;
using Project.EF.Api.Models;

namespace Project.EF.Api.EFContext;

public class TareasContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit =
        [
            new Category() { CategoryId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca89d"), Name = "Pending Activities", Weight = 50 },
            new Category() { CategoryId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca891"), Name = "Personal Activities", Weight = 60 },
        ];

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(x => x.CategoryId);
            category.Property(x => x.Name).IsRequired().HasMaxLength(150);
            category.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
            category.Property(x => x.Weight);
            category.HasData(categoriesInit);
        });

        List<Tarea> tareasInit =
        [
        new Tarea() { TareaId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca810"), CategoryId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca89d"), Title = "Renew car insurance", TareaPriority = Priority.High, CreationDate = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc) },
        new Tarea() { TareaId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca811"), CategoryId = Guid.Parse("e29765db-6368-49b3-9a97-88f8be1ca891"), Title = "Watch anime", TareaPriority = Priority.Low, CreationDate = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc) },
        ];

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Task");
            tarea.HasKey(x => x.TareaId);
            tarea.HasOne(x => x.Category).WithMany(x => x.Tareas).HasForeignKey(x => x.CategoryId);
            tarea.Property(x => x.Title).IsRequired().HasMaxLength(150);
            tarea.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
            tarea.Ignore(x => x.Resume);
            tarea.Property(x => x.TareaPriority);
            tarea.Property(x => x.CreationDate).HasDefaultValueSql("now()");
            tarea.HasData(tareasInit);
        });
    }
}