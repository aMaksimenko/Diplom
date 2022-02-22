using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ICatalogStreamRepository _catalogStreamRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        ICatalogStreamRepository catalogStreamRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _catalogStreamRepository = catalogStreamRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(
        int pageSize,
        int pageIndex,
        Dictionary<CatalogTypeFilter, int>? filters)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                int? genreFilter = null;

                if (filters != null)
                {
                    if (filters.TryGetValue(CatalogTypeFilter.Genre, out var genre))
                    {
                        genreFilter = genre;
                    }
                }

                var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize, genreFilter);

                if (result == null)
                {
                    return null;
                }

                var response = new PaginatedItemsResponse<CatalogItemDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };

                return response;
            });
    }

    public async Task<PaginatedItemsResponse<CatalogStreamDto>?> GetCatalogStreamsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogStreamRepository.GetByPageAsync(pageIndex, pageSize);

                if (result == null)
                {
                    return null;
                }

                var response = new PaginatedItemsResponse<CatalogStreamDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(s => _mapper.Map<CatalogStreamDto>(s)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };

                return response;
            });
    }

    public async Task<CatalogStreamDto> GetStreamByIdAsync(int id)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogStreamRepository.GetByIdAsync(id);

                return _mapper.Map<CatalogStreamDto>(result);
            });
    }

    public async Task<CatalogItemDto> GetByIdAsync(int id)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByIdAsync(id);

                return _mapper.Map<CatalogItemDto>(result);
            });
    }

    public async Task<IEnumerable<CatalogItemDto>> GetByGenreAsync(int genreId)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByGenreAsync(genreId);

                return result.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList();
            });
    }

    public async Task<IEnumerable<CatalogGenreDto>> GetGenresAsync()
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetGenresAsync();

                return result.Select(s => _mapper.Map<CatalogGenreDto>(s)).ToList();
            });
    }
}