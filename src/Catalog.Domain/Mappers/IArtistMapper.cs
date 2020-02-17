using Catalog.Domain.Entities;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public interface IArtistMapper
    {
        ArtistResponse Map(Artist artist);
        Artist Map(AddArtistRequest request);
    }
} 