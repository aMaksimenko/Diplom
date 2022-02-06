namespace Catalog.Host.Models.Requests.Genre;

public class UpdateGenreRequest
{
    public int Id { get; set; }
    public string Genre { get; set; } = null!;
}