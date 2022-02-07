using Basket.Host.Models;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
    
    public async Task UpdateItems(string userId, string data)
    {
       await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<GetItemsResponse> GetItems(string userId)
    {
        var result = await _cacheService.GetAsync<string>(userId);
        
        return new GetItemsResponse() { Data = result };
    }
}