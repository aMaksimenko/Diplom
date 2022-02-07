using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models;

public class UpdateItemsRequest
{
    [Required] 
    public string Data { get; set; } = null!;
}