using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Stream;

public class GetByIdStreamRequest
{
    [Required]
    public int Id { get; set; }
}