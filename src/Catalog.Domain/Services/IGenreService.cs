using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetGenreAsync();
        Task<GenreResponse> GetGenreAsync(GetGenreRequest request);
        Task<GenreResponse> AddGenreAsync(AddGenreRequest request);
    }
}
