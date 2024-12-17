using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Data;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public class LocationServiceDb : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationServiceDb(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations
                .Include(location => location.Boss)
                    .ThenInclude(boss => boss.UniqueItem)
                .ToListAsync();
        }

        public async Task<Location?> GetLocationById(int id)
        {
            return await _context.Locations
                .Include(location => location.Boss)
                    .ThenInclude(boss => boss.UniqueItem)
                .FirstOrDefaultAsync(location => location.Id == id);
        }

        public async Task<List<Location>> SearchLocationsByName(string name)
        {
            var locations = await _context.Locations
                .Include(location => location.Boss)
                    .ThenInclude(boss => boss.UniqueItem)
                .ToListAsync();
            return locations
                .Where(location => location.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<Location?> UpdateLocation(int id, Location updatedLocation)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(loc => loc.Id == id);
            if (location is not null)
            {
                location.Name = updatedLocation.Name;
                location.Description = updatedLocation.Description;
                location.Image = updatedLocation.Image;
                location.BossId = updatedLocation.BossId;
                location.Boss = updatedLocation.Boss;

                await _context.SaveChangesAsync();
            }
            return location;
        }

        public async Task DeleteLocation(int id)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(loc => loc.Id == id);
            if (location is not null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}
