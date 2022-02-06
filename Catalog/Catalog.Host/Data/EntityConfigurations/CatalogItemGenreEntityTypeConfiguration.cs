using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogItemGenreEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogItemGenre>
{
    public void Configure(EntityTypeBuilder<CatalogItemGenre> builder)
    {
        builder.ToTable("CatalogItemGenre");
        builder.HasKey(ci => ci.Id);

        builder.HasOne(p => p.CatalogItem)
            .WithMany(p => p.CatalogItemGenres)
            .HasForeignKey(p => p.CatalogItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.CatalogGenre)
            .WithMany(p => p.CatalogItemGenres)
            .HasForeignKey(p => p.CatalogGenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}