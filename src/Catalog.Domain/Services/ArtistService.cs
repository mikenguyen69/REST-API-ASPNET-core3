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
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IArtistMapper _artistMapper;
        private readonly IItemMapper _itemMapper;

        public ArtistService(IArtistRepository artistRepository, IItemRepository itemRepository, ArtistMapper artistMapper, ItemMapper itemMapper)
        {
            _artistRepository = artistRepository;
            _itemRepository = itemRepository;
            _artistMapper = artistMapper;
            _itemMapper = itemMapper;
        }

        public Task<ArtistResponse> AddArtistAsync(AddArtistRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArtistResponse>> GetArtistAsync()
        {
            var result = await _artistRepository.GetAsync();

            return result.Select(_artistMapper.Map);
        }

        public async Task<ArtistResponse> GetArtistAsync(GetArtistRequest request)
        {
            var result = await _artistRepository.GetAsync(request.Id);

            return result == null ? null : _artistMapper.Map(result);
        }
    }
}
