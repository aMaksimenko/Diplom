using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? genreFilter);
    Task<CatalogItem?> GetByIdAsync(int id);
    Task<IEnumerable<CatalogItem>> GetByGenreAsync(int genreId);
    Task<IEnumerable<CatalogGenre>> GetGenresAsync();

    Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price);

    Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price);

    Task<bool> DeleteAsync(int id);
}