using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Mappers;
using Catalog.Domain.Repositories;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IGenreMapper _genreMapper;
        private readonly IItemMapper _itemMapper;

        public GenreService(IGenreRepository GenreRepository, IItemRepository itemRepository, GenreMapper GenreMapper, ItemMapper itemMapper)
        {
            _genreRepository = GenreRepository;
            _itemRepository = itemRepository;
            _genreMapper = GenreMapper;
            _itemMapper = itemMapper;
        }

        public Task<GenreResponse> AddGenreAsync(AddGenreRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GenreResponse>> GetGenreAsync()
        {
            var result = await _genreRepository.GetAsync();

            return result.Select(_genreMapper.Map);
        }

        public async Task<GenreResponse> GetGenreAsync(GetGenreRequest request)
        {
            var result = await _genreRepository.GetAsync(request.Id);

            return result == null ? null : _genreMapper.Map(result);
        }
    }
}
