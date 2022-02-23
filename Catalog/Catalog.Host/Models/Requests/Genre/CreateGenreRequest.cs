using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Genre;

public class CreateGenreRequest
{
    [Required]
    public string Genre { get; set; } = null!;
}