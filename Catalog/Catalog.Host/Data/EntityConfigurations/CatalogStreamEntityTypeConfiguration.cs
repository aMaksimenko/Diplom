using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogStreamEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogStream>
{
    public void Configure(EntityTypeBuilder<CatalogStream> builder)
    {
        builder.ToTable("CatalogStream");
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(ci => ci.CoverFileName).IsRequired(false);
        builder.Property(ci => ci.Description).IsRequired();
        builder.Property(ci => ci.Price).IsRequired();
    }
}