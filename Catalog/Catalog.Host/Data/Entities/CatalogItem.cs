namespace Catalog.Host.Data.Entities;

public class CatalogItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string CoverFileName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Imdb { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public virtual List<CatalogItemGenre> CatalogItemGenres { get; set; } = null!;
}