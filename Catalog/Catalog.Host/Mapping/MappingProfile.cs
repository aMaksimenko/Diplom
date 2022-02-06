using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember(
                "PictureUrl",
                opt
                    => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.CoverFileName))
            .ForMember(
                "Genres",
                opt
                    => opt.MapFrom<CatalogGenresResolver, List<CatalogItemGenre>>(c => c.CatalogItemGenres));
        CreateMap<CatalogGenre, CatalogGenreDto>();
    }
}