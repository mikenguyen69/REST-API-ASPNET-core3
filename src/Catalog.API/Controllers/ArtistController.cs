using System;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Exceptions;
using Catalog.API.ResponseModels;
using Catalog.Domain.Requests;
using Catalog.Domain.Responses;
using Catalog.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/artist")]
    [ApiController]
    [JsonException]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _artistService.GetArtistAsync();

            var totalItems = result.ToList().Count;

            var itemsOnPage = result
                .OrderBy(c => c.ArtistName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedItemsResponseModel<ArtistResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _artistService.GetArtistAsync(new GetArtistRequest { Id = id });

            return Ok(result);
        }

        public async Task<IActionResult> GetItemsById(Guid id)
        {
            var result = await _artistService.GetItemsByArtistIdAsync(new GetArtistRequest { Id = id });
            return Ok(result);
        }
    }
}
