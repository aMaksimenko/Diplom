using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Product;

public class CreateProductRequest
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string CoverFileName { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public double Imdb { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public double Price { get; set; }
}