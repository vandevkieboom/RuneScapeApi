using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Data;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public class UniqueItemServiceDb : IUniqueItemService
    {
        private readonly AppDbContext _context;

        public UniqueItemServiceDb(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UniqueItem>> GetUniqueItems()
        {
            return await _context.UniqueItems.ToListAsync();
        }

        public async Task<UniqueItem?> GetUniqueItemById(int id)
        {
            return await _context.UniqueItems.FindAsync(id);
        }

        public async Task<List<UniqueItem>> SearchUniqueItemsByName(string name)
        {
            var uniqueItems = await _context.UniqueItems.ToListAsync();
            return uniqueItems
                .Where(uniqueItem => uniqueItem.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task<List<UniqueItem>> SearchUniqueItemsByPriceRange(int minPrice, int maxPrice)
        {
            return await _context.UniqueItems
                .Where(uniqueItem => uniqueItem.Price >= minPrice && uniqueItem.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<List<UniqueItem>> SearchUniqueItemsByHighAlchRange(int minHighAlch, int maxHighAlch)
        {
            return await _context.UniqueItems
                .Where(uniqueItem => uniqueItem.HighAlch >= minHighAlch && uniqueItem.HighAlch <= maxHighAlch)
                .ToListAsync();
        }

        public async Task AddUniqueItem(UniqueItem uniqueItem)
        {
            _context.UniqueItems.Add(uniqueItem);
            await _context.SaveChangesAsync();
        }

        public async Task<UniqueItem?> UpdateUniqueItem(int id, UniqueItem updatedUniqueItem)
        {
            var uniqueItem = await _context.UniqueItems.FindAsync(id);
            if (uniqueItem != null)
            {
                uniqueItem.Name = updatedUniqueItem.Name;
                uniqueItem.Price = updatedUniqueItem.Price;
                uniqueItem.HighAlch = updatedUniqueItem.HighAlch;
                uniqueItem.Image = updatedUniqueItem.Image;

                await _context.SaveChangesAsync();
            }
            return uniqueItem;
        }

        public async Task DeleteUniqueItem(int id)
        {
            var uniqueItem = await _context.UniqueItems.FindAsync(id);
            if (uniqueItem != null)
            {
                _context.UniqueItems.Remove(uniqueItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}