using Catalog.Host.Models.Requests.Stream;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogstream")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogStreamController : ControllerBase
{
    private readonly ILogger<CatalogStreamController> _logger;
    private readonly ICatalogStreamService _catalogStreamService;

    public CatalogStreamController(
        ILogger<CatalogStreamController> logger,
        ICatalogStreamService catalogStreamService)
    {
        _logger = logger;
        _catalogStreamService = catalogStreamService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateStreamRequest request)
    {
        var result = await _catalogStreamService.CreateAsync(
            request.Title,
            request.CoverFileName,
            request.Description,
            request.Price);

        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateStreamRequest request)
    {
        await _catalogStreamService.UpdateAsync(
            request.Id,
            request.Title,
            request.CoverFileName,
            request.Description,
            request.Price);

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteStreamRequest request)
    {
        await _catalogStreamService.DeleteAsync(request.Id);

        return Ok();
    }
}