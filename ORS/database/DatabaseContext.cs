using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Models;

namespace ORS.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
    public DbSet<Region> Regions { get; set; }

    // protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // Specify schema if needed
        modelBuilder.HasDefaultSchema("public");

        // Additional configuration
    }
}