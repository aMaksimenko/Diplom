using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Genre;

public class DeleteGenreRequest
{
    [Required]
    public int Id { get; set; }
}