using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.Product;
using Catalog.Host.Models.Requests.Stream;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly IOptions<CatalogConfig> _config;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(GetByIdProductRequest request)
    {
        var result = await _catalogService.GetByIdAsync(request.Id);

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogStreamDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Streams(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogStreamsAsync(request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CatalogStreamDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetStreamById(GetByIdStreamRequest request)
    {
        var result = await _catalogService.GetStreamByIdAsync(request.Id);

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByGenre(GetByGenreIdProductRequest request)
    {
        var result = await _catalogService.GetByGenreAsync(request.GenreId);

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<CatalogGenreDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetGenres()
    {
        var result = await _catalogService.GetGenresAsync();

        return Ok(result);
    }
}