using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogStreamRepository : ICatalogStreamRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogStreamRepository> _logger;

    public CatalogStreamRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogStreamRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogStream>> GetByPageAsync(
        int pageIndex,
        int pageSize)
    {
        var totalItems = await _dbContext.CatalogStreams.LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogStreams.OrderBy(c => c.Title)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogStream>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogStream?> GetByIdAsync(int id)
    {
        var res = await _dbContext.CatalogStreams.FirstOrDefaultAsync(ci => ci.Id == id);

        return res;
    }

    public async Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double price)
    {
        var item = await _dbContext.CatalogStreams.AddAsync(
            new CatalogStream()
            {
                Title = title,
                CoverFileName = coverFileName,
                Description = description,
                Price = price
            });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double price)
    {
        var item = await _dbContext.CatalogStreams.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            item.Title = title;
            item.CoverFileName = coverFileName;
            item.Description = description;
            item.Price = price;

            _dbContext.CatalogStreams.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogStreams.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            _dbContext.CatalogStreams.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }
}