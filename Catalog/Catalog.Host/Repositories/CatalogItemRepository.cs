using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(
        int pageIndex,
        int pageSize,
        int? genreFilter)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems
            .Include(i => i.CatalogItemGenres)
            .ThenInclude(i => i.CatalogGenre);

        if (genreFilter.HasValue)
        {
            query = query.Where(
                w => w.CatalogItemGenres.FirstOrDefault(i => i.CatalogGenreId == genreFilter.Value) != null);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query.OrderBy(c => c.Title)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        var res = await _dbContext.CatalogItems
            .Include(i => i.CatalogItemGenres)
            .ThenInclude(i => i.CatalogGenre)
            .FirstOrDefaultAsync(ci => ci.Id == id);

        return res;
    }

    public async Task<IEnumerable<CatalogItem>> GetByGenreAsync(int genreId)
    {
        var res = await _dbContext.CatalogItems
            .Include(i => i.CatalogItemGenres)
            .ThenInclude(i => i.CatalogGenre)
            .Where(w => w.CatalogItemGenres.FirstOrDefault(i => i.CatalogGenreId == genreId) != null)
            .ToListAsync();

        return res;
    }

    public async Task<IEnumerable<CatalogGenre>> GetGenresAsync()
    {
        var res = await _dbContext.CatalogGenres
            .ToListAsync();

        return res;
    }

    public async Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price)
    {
        var item = await _dbContext.CatalogItems.AddAsync(
            new CatalogItem
            {
                Title = title,
                CoverFileName = coverFileName,
                Description = description,
                Imdb = imdb,
                Year = year,
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
        double imdb,
        int year,
        double price)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            item.Title = title;
            item.CoverFileName = coverFileName;
            item.Description = description;
            item.Imdb = imdb;
            item.Year = year;
            item.Price = price;

            _dbContext.CatalogItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            _dbContext.CatalogItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }
}