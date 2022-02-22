namespace Catalog.Host.Models.Requests.Stream;

public class CreateStreamRequest
{
    public string Title { get; set; } = null!;
    public string CoverFileName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}