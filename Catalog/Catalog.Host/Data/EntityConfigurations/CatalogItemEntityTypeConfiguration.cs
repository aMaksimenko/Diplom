using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogItemEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("CatalogItem");
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(ci => ci.CoverFileName).IsRequired(false);
        builder.Property(ci => ci.Imdb).IsRequired();
        builder.Property(ci => ci.Year).IsRequired();
        builder.Property(ci => ci.Description).IsRequired();
        builder.Property(ci => ci.Price).IsRequired();
    }
}