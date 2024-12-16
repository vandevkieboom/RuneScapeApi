using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public class LocationService : ILocationService
    {
        private static readonly List<Location> _allLocations = new()
        {
            new Location { Id = 1, Name = "Zul-Andra", Description = "A remote island known for its unique teleportation methods and fishing spots.", Image = "https://oldschool.runescape.wiki/images/Zul-Andra.png?bc8fb", BossId = 1 },
            new Location { Id = 2, Name = "Ungael", Description = "The lair of Vorkath, a powerful dragon found in the Wilderness.", Image = "https://oldschool.runescape.wiki/images/Ungael.png?2e330", BossId = 2 },
            new Location { Id = 3, Name = "Kraken Cove", Description = "A hidden cove where the Kraken resides, known for its treasure.", Image = "https://oldschool.runescape.wiki/images/Kraken_Cove.png?3be60", BossId = 3 },
            new Location { Id = 4, Name = "God Wars Dungeon", Description = "A battleground for gods, featuring powerful bosses and their minions.", Image = "https://oldschool.runescape.wiki/images/God_Wars_Dungeon_Entrance.png?8b0f5", BossId = 4 },
            new Location { Id = 5, Name = "Cerberus' Lair", Description = "A hellish cave home to Cerberus, guarded by hellhounds.", Image = "https://oldschool.runescape.wiki/images/Cerberus%27_Lair.png?75520", BossId = 5 },
            new Location { Id = 6, Name = "Waterbirth Island Dungeon", Description = "An underwater dungeon filled with fearsome creatures and guarded by Dagannoth kings.", Image = "https://oldschool.runescape.wiki/images/Waterbirth_Island_Dungeon_1.png?c9813", BossId = 6 },
            new Location { Id = 7, Name = "Morytania Spider Cave", Description = "A cave filled with dangerous spiders in the Morytania region.", Image = "https://oldschool.runescape.wiki/images/Morytania_Spider_Cave.png?74d5c", BossId = 7 },
            new Location { Id = 8, Name = "The Stranglewood", Description = "A thick forest known for its dangerous creatures and resources.", Image = "https://oldschool.runescape.wiki/images/The_Stranglewood.png?d5f29", BossId = 8 },
            new Location { Id = 9, Name = "The Scar", Description = "The home of the gnomes, located in the Tree Gnome Stronghold.", Image = "https://oldschool.runescape.wiki/images/The_Scar.png?61378", BossId = 9 },
            new Location { Id = 10, Name = "King Black Dragon Lair", Description = "A lair deep in the wilderness, home to the King Black Dragon.", Image = "https://oldschool.runescape.wiki/images/KBD_Lair_%28interior%29.png?35aa6", BossId = 10 }
        };

        public Task AddLocation(Location location)
        {
            _allLocations.Add(location);
            return Task.CompletedTask;
        }

        public Task<List<Location>> GetLocations()
        {
            return Task.FromResult(_allLocations);
        }

        public Task<Location?> GetLocationById(int id)
        {
            var location = _allLocations.FirstOrDefault(location => id == location.Id);
            return Task.FromResult(location);
        }

        public Task<List<Location>> SearchLocationsByName(string name)
        {
            var locations = _allLocations.Where(location => location.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Task.FromResult(locations);
        }

        public Task<Location?> UpdateLocation(int id, Location updatedLocation)
        {
            var location = _allLocations.FirstOrDefault(location => id == location.Id);
            if (location != null)
            {
                location.Name = updatedLocation.Name;
                location.Description = updatedLocation.Description;
                location.Image = updatedLocation.Image;
                location.BossId = updatedLocation.BossId;
            }
            return Task.FromResult(location);
        }

        public Task DeleteLocation(int id)
        {
            var location = _allLocations.FirstOrDefault(location => id == location.Id);
            if (location != null)
            {
                _allLocations.Remove(location);
            }
            return Task.CompletedTask;
        }
    }
}
