using Catalog.Domain.Entities;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public class ArtistMapper : IArtistMapper
    {
        public ArtistResponse Map(Artist artist)
        {
            if (artist == null) return null;

            return new ArtistResponse
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.ArtistName
            };
        }

        public Artist Map(AddArtistRequest request)
        {
            if (request == null) return null;

            return new Artist
            {
                ArtistName = request.ArtistName
            };
        }
    }
}