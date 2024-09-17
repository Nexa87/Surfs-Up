using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;
public class SurfboardDb : DbContext
{
    public DbSet<Surfboard> Surfboards { get; set; } = null!;
    public SurfboardDb(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Surfboard>().ToTable(nameof(Surfboard));
    }
}