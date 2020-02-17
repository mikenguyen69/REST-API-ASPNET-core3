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

        public GenreService(IGenreRepository genreRepository, IItemRepository itemRepository, IGenreMapper genreMapper, IItemMapper itemMapper)
        {
            _genreRepository = genreRepository;
            _itemRepository = itemRepository;
            _genreMapper = genreMapper;
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

        public async Task<IEnumerable<ItemResponse>> GetItemsByGenreIdAsync(GetGenreRequest request)
        {
            var result = await _itemRepository.GetItemsByArtistIdAsync(request.Id);

            return result.Select(_itemMapper.Map);
        }
    }
}
