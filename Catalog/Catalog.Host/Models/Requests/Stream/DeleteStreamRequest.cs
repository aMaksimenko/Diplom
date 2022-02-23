using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Stream;

public class DeleteStreamRequest
{
    [Required]
    public int Id { get; set; }
}