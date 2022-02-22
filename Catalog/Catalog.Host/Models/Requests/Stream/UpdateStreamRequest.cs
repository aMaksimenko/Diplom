namespace Catalog.Host.Models.Requests.Stream;

public class UpdateStreamRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string CoverFileName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}