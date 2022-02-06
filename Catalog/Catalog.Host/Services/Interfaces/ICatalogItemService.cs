namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price);

    Task<bool> UpdateAsync(
        int id,
        string title,
        string coverFileName,
        string description,
        double imdb,
        int year,
        double price);

    Task<bool> DeleteAsync(int id);
}