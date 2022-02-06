namespace Catalog.Host.Data.Entities;

public class CatalogGenre
{
    public int Id { get; set; }
    public string Genre { get; set; } = null!;
    public virtual List<CatalogItemGenre> CatalogItemGenres { get; set; } = null!;
}