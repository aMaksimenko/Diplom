namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Imdb { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public List<CatalogGenreDto> Genres { get; set; } = null!;
}
