using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Genre;

public class UpdateGenreRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Genre { get; set; } = null!;
}