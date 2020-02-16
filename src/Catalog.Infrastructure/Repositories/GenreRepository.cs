using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly CatalogContext _catalogContext;
        public IUnitOfWork UnitOfWork => _catalogContext;

        public GenreRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public Genre Add(Genre item)
        {
            return
                _catalogContext.Genres.Add(item).Entity;
        }

        public async Task<IEnumerable<Genre>> GetAsync()
        {
            return await _catalogContext.Genres
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Genre> GetAsync(Guid id)
        {
            var Genre = await _catalogContext.Genres.FindAsync(id);

            if (Genre == null) return null;

            _catalogContext.Entry(Genre).State = EntityState.Detached;

            return Genre;
        }
    }
}
