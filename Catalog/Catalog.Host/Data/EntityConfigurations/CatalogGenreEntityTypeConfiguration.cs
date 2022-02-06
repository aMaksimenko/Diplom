using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogGenreEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogGenre>
{
    public void Configure(EntityTypeBuilder<CatalogGenre> builder)
    {
        builder.ToTable("CatalogGenre");
        builder.HasKey(ci => ci.Id);
        builder.Property(cb => cb.Genre)
            .IsRequired()
            .HasMaxLength(100);
    }
}