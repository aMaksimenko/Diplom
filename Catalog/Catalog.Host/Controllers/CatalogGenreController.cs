using Catalog.Host.Models.Requests.Genre;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.cataloggenre")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogGenreController : ControllerBase
{
    private readonly ILogger<CatalogGenreController> _logger;
    private readonly ICatalogGenreService _catalogGenreService;

    public CatalogGenreController(
        ILogger<CatalogGenreController> logger,
        ICatalogGenreService catalogGenreService)
    {
        _logger = logger;
        _catalogGenreService = catalogGenreService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateGenreRequest request)
    {
        var result = await _catalogGenreService.CreateAsync(request.Genre);

        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateGenreRequest request)
    {
        await _catalogGenreService.UpdateAsync(request.Id, request.Genre);

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteGenreRequest request)
    {
        await _catalogGenreService.DeleteAsync(request.Id);

        return Ok();
    }
}