using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository {
        private readonly CatalogContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ItemRepository(CatalogContext context) {
            _context = context;
        }

        public Item Add(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            return await _context
                .Items
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var item = await _context.Items
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Genre)
                .Include(x => x.Artist).FirstOrDefaultAsync();

            return item;
        }

        public Item Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;

            return item;
        }

        public Item Delete(Item item)
        {
            throw new NotImplementedException();
        }
    }
}