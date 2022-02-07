using Basket.Host.Models;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task UpdateItems(string userId, string data);
    Task<GetItemsResponse> GetItems(string userId);
}