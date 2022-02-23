using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Product;

public class GetByGenreIdProductRequest
{
    [Required]
    public int GenreId { get; set; }
}