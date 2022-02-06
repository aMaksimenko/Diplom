using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogGenreRepository : ICatalogGenreRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogGenreRepository> _logger;

    public CatalogGenreRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogGenreRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> CreateAsync(string title)
    {
        var item = await _dbContext.CatalogGenres.AddAsync(
            new CatalogGenre()
            {
                Genre = title
            });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> UpdateAsync(int id, string title)
    {
        var item = await _dbContext.CatalogGenres.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            item.Genre = title;
            _dbContext.CatalogGenres.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogGenres.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            _dbContext.CatalogGenres.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        return item != null;
    }
}