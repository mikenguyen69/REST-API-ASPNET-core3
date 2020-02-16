using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistResponse>> GetArtistAsync();
        Task<ArtistResponse> GetArtistAsync(GetArtistRequest request);
        Task<ArtistResponse> AddArtistAsync(AddArtistRequest request);
    }
}
