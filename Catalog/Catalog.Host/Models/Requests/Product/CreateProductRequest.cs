namespace Catalog.Host.Models.Requests.Product;

public class CreateProductRequest
{
    public string Title { get; set; } = null!;
    public string CoverFileName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Imdb { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}