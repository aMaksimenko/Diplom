namespace Catalog.Host.Data.Entities;

public class CatalogStream
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string CoverFileName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}