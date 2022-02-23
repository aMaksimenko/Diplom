using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Product;

public class DeleteProductRequest
{
    [Required]
    public int Id { get; set; }
}