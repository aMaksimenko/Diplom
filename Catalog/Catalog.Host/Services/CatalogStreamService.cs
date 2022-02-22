using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogStreamService : BaseDataService<ApplicationDbContext>, ICatalogStreamService
{
    private readonly ICatalogStreamRepository _catalogStreamRepository;

    public CatalogStreamService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogStreamRepository catalogStreamRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogStreamRepository = catalogStreamRepository;
    }

    public Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double price)
    {
        return ExecuteSafeAsync(
            () => _catalogStreamRepository.CreateAsync(
                title,
                coverFileName,
                description,
                price));
    }

    public Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double price)
    {
        return ExecuteSafeAsync(
            () => _catalogStreamRepository.UpdateAsync(
                id,
                title,
                coverFileName,
                description,
                price));
    }

    public Task<bool> DeleteAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogStreamRepository.DeleteAsync(id));
    }
}