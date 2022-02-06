namespace Catalog.Host.Data.Entities;

public class CatalogItemGenre
{
    public int Id { get; set; }
    public int CatalogItemId { get; set; }
    public virtual CatalogItem CatalogItem { get; set; } = null!;
    public int CatalogGenreId { get; set; }
    public virtual CatalogGenre CatalogGenre { get; set; } = null!;
}