namespace Catalog.Host.Services.Interfaces;

public interface ICatalogStreamService
{
    Task<int?> CreateAsync(
        string title,
        string coverFileName,
        string description,
        double price);

    Task<bool> UpdateAsync(
        int id,
        string? title,
        string? coverFileName,
        string? description,
        double? price);

    Task<bool> DeleteAsync(int id);
}