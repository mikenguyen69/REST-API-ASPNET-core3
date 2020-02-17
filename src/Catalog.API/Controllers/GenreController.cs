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
    [Route("api/genre")]
    [ApiController]
    [JsonException]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _genreService.GetGenreAsync();

            var totalItems = result.ToList().Count;

            var itemsOnPage = result
                .OrderBy(c => c.GenreDescription)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedItemsResponseModel<GenreResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _genreService.GetGenreAsync(new GetGenreRequest { Id = id });

            return Ok(result);
        }

        public async Task<IActionResult> GetItemsById(Guid id)
        {
            var result = await _genreService.GetItemsByGenreIdAsync(new GetGenreRequest { Id = id });
            return Ok(result);
        }
    }
}
