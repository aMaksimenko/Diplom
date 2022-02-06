namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogGenreRepository
{
    Task<int?> CreateAsync(string title);
    Task<bool> UpdateAsync(int id, string title);
    Task<bool> DeleteAsync(int id);
}