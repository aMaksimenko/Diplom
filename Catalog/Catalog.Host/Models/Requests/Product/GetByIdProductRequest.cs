using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Product;

public class GetByIdProductRequest
{
    [Required]
    public int Id { get; set; }
}