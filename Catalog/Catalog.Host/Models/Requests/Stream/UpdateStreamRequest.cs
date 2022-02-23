using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Stream;

public class UpdateStreamRequest
{
    [Required]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? CoverFileName { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
}