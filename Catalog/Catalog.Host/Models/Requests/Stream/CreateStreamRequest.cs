using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Stream;

public class CreateStreamRequest
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string CoverFileName { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public double Price { get; set; }
}