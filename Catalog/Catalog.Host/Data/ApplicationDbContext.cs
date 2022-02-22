using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; set; } = null!;
    public DbSet<CatalogStream> CatalogStreams { get; set; } = null!;
    public DbSet<CatalogGenre> CatalogGenres { get; set; } = null!;
    public DbSet<CatalogItemGenre> CatalogItemGenres { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogStreamEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogGenreEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogItemGenreEntityTypeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }
}