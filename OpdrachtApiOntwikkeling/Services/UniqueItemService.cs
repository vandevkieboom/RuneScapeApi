using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public class UniqueItemService : IUniqueItemService
    {
        private static readonly List<UniqueItem> _allUniqueItems = new()
        {
            new UniqueItem { Id = 1, Name = "Tanzanite fang", Price = 5784502, HighAlch = 66000, Image = "https://oldschool.runescape.wiki/images/Tanzanite_fang_detail.png?859ba" },
            new UniqueItem { Id = 2, Name = "Skeletal visage", Price = 13440000, HighAlch = 900000, Image = "https://oldschool.runescape.wiki/images/Skeletal_visage_detail.png?bccc7" },
            new UniqueItem { Id = 3, Name = "Kraken tentacle", Price = 561782, HighAlch = 50004, Image = "https://oldschool.runescape.wiki/images/Kraken_tentacle_detail.png?e5f2a" },
            new UniqueItem { Id = 4, Name = "Bandos chestplate", Price = 28918892, HighAlch = 174006, Image = "https://oldschool.runescape.wiki/images/Bandos_chestplate_detail.png?98028" },
            new UniqueItem { Id = 5, Name = "Primordial crystal", Price = 24435004, HighAlch = 27000, Image = "https://oldschool.runescape.wiki/images/Primordial_crystal_detail.png?9c62f" },
            new UniqueItem { Id = 6, Name = "Berserker ring", Price = 4460382, HighAlch = 6000, Image = "https://oldschool.runescape.wiki/images/Berserker_ring_detail.png?81f8b" },
            new UniqueItem { Id = 7, Name = "Araxyte fang", Price = 70399444, HighAlch = 120000, Image = "https://oldschool.runescape.wiki/images/Araxyte_fang_detail.png?43deb" },
            new UniqueItem { Id = 8, Name = "Executioner's axe head", Price = 370436553, HighAlch = 30000, Image = "https://oldschool.runescape.wiki/images/Executioner%27s_axe_head_detail.png?b410d" },
            new UniqueItem { Id = 9, Name = "Virtus robe top", Price = 66788559, HighAlch = 360000, Image = "https://oldschool.runescape.wiki/images/Virtus_robe_top_detail.png?b2b4a" },
            new UniqueItem { Id = 10, Name = "Draconic visage", Price = 4054769, HighAlch = 450000, Image = "https://oldschool.runescape.wiki/images/Draconic_visage_detail.png?6edab" }
        };

        public Task<List<UniqueItem>> GetUniqueItems()
        {
            return Task.FromResult(_allUniqueItems);
        }

        public Task<UniqueItem?> GetUniqueItemById(int id)
        {
            var item = _allUniqueItems.FirstOrDefault(item => id == item.Id);
            return Task.FromResult(item);
        }

        public Task<List<UniqueItem>> SearchUniqueItemsByName(string name)
        {
            var uniqueItems = _allUniqueItems.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Task.FromResult(uniqueItems);
        }

        public Task<List<UniqueItem>> SearchUniqueItemsByPriceRange(int minPrice, int maxPrice)
        {
            var uniqueItems = _allUniqueItems.Where(item => item.Price >= minPrice && item.Price <= maxPrice).ToList();
            return Task.FromResult(uniqueItems);
        }

        public Task<List<UniqueItem>> SearchUniqueItemsByHighAlchRange(int minHighAlch, int maxHighAlch)
        {
            var uniqueItems = _allUniqueItems.Where(item => item.HighAlch >= minHighAlch && item.HighAlch <= maxHighAlch).ToList();
            return Task.FromResult(uniqueItems);
        }

        public Task AddUniqueItem(UniqueItem uniqueItem)
        {
            int newId = 1;
            while (_allUniqueItems.Any(item => item.Id == newId))
            {
                newId++;
            }
            uniqueItem.Id = newId;
            _allUniqueItems.Add(uniqueItem);
            return Task.CompletedTask;
        }

        public Task<UniqueItem?> UpdateUniqueItem(int id, UniqueItem updatedUniqueItem)
        {
            var item = _allUniqueItems.FirstOrDefault(item => id == item.Id);
            if (item != null)
            {
                item.Name = updatedUniqueItem.Name;
                item.Price = updatedUniqueItem.Price;
                item.HighAlch = updatedUniqueItem.HighAlch;
                item.Image = updatedUniqueItem.Image;
            }
            return Task.FromResult(item);
        }

        public Task DeleteUniqueItem(int id)
        {
            var item = _allUniqueItems.FirstOrDefault(item => id == item.Id);
            if (item != null)
            {
                _allUniqueItems.Remove(item);
            }
            return Task.CompletedTask;
        }
    }
}
