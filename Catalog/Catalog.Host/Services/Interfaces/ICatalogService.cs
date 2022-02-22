using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(
        int pageSize,
        int pageIndex,
        Dictionary<CatalogTypeFilter, int>? filters);

    Task<CatalogItemDto> GetByIdAsync(int id);

    Task<PaginatedItemsResponse<CatalogStreamDto>?> GetCatalogStreamsAsync(
        int pageSize,
        int pageIndex);

    Task<CatalogStreamDto> GetStreamByIdAsync(int id);

    Task<IEnumerable<CatalogItemDto>> GetByGenreAsync(int genreId);
    Task<IEnumerable<CatalogGenreDto>> GetGenresAsync();
}