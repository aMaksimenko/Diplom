using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price)
    {
        return ExecuteSafeAsync(
            () => _catalogItemRepository.CreateAsync(
                title,
                coverFileName,
                description,
                imdb,
                year,
                price));
    }

    public Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price)
    {
        return ExecuteSafeAsync(
            () => _catalogItemRepository.UpdateAsync(
                id,
                title,
                coverFileName,
                description,
                imdb,
                year,
                price));
    }

    public Task<bool> DeleteAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.DeleteAsync(id));
    }
}