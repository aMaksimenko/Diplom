using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogGenreService : BaseDataService<ApplicationDbContext>, ICatalogGenreService
{
    private readonly ICatalogGenreRepository _catalogGenreRepository;

    public CatalogGenreService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogGenreRepository catalogGenreRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogGenreRepository = catalogGenreRepository;
    }

    public Task<int?> CreateAsync(string title)
    {
        return ExecuteSafeAsync(() => _catalogGenreRepository.CreateAsync(title));
    }

    public Task<bool> UpdateAsync(int id, string title)
    {
        return ExecuteSafeAsync(() => _catalogGenreRepository.UpdateAsync(id, title));
    }

    public Task<bool> DeleteAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogGenreRepository.DeleteAsync(id));
    }
}