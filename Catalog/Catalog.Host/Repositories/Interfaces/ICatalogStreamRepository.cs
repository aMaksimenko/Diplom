using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogStreamRepository
{
    Task<PaginatedItems<CatalogStream>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogStream?> GetByIdAsync(int id);

    Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double price);

    Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double price);

    Task<bool> DeleteAsync(int id);
}