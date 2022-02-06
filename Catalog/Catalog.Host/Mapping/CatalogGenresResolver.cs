using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class CatalogGenresResolver :
    IMemberValueResolver<CatalogItem, CatalogItemDto, List<CatalogItemGenre>, object>
{
    public object Resolve(
        CatalogItem source,
        CatalogItemDto destination,
        List<CatalogItemGenre> sourceMember,
        object destMember,
        ResolutionContext context)
    {
        var result = new List<CatalogGenreDto>();

        foreach (var item in sourceMember)
        {
            result.Add(
                new CatalogGenreDto()
                {
                    Id = item.CatalogGenre.Id,
                    Genre = item.CatalogGenre.Genre
                });
        }

        return result;
    }
}