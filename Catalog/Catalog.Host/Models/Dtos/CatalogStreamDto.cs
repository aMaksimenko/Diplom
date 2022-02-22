namespace Catalog.Host.Models.Dtos;

public class CatalogStreamDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}