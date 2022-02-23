using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Product;

public class UpdateProductRequest
{
    [Required]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? CoverFileName { get; set; }
    public string? Description { get; set; }
    public double? Imdb { get; set; }
    public int? Year { get; set; }
    public double? Price { get; set; }
}