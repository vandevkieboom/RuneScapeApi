using OpdrachtApiOntwikkelingDeel1.Models;

namespace OpdrachtApiOntwikkelingDeel1.Services
{
    public interface ILocationService
    {
        public Task AddLocation(Location location);
        public Task<List<Location>> GetLocations();
        public Task<Location?> GetLocationById(int id);
        public Task<List<Location>> SearchLocationsByName(string name);
        public Task<Location?> UpdateLocation(int id, Location updatedLocation);
        public Task DeleteLocation(int id);
    }
}
