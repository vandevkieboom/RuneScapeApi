using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public interface IUniqueItemService
    {
        public Task<List<UniqueItem>> GetUniqueItems();
        public Task<UniqueItem?> GetUniqueItemById(int id);
        public Task<List<UniqueItem>> SearchUniqueItemsByName(string name);
        public Task<List<UniqueItem>> SearchUniqueItemsByPriceRange(int minPrice, int maxPrice);
        public Task<List<UniqueItem>> SearchUniqueItemsByHighAlchRange(int minHighAlch, int maxHighAlch);
        public Task AddUniqueItem(UniqueItem uniqueItem);
        public Task<UniqueItem?> UpdateUniqueItem(int id, UniqueItem updatedUniqueItem);
        public Task DeleteUniqueItem(int id);
    }
}
