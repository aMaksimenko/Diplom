using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateItems(UpdateItemsRequest data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

        await _basketService.UpdateItems(basketId!, data.Data);
        return Ok(new UpdateItemsResponse() { IsSuccess = true });
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItems()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.GetItems(basketId!);

        return Ok(response);
    }
}