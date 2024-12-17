using Microsoft.AspNetCore.Mvc;
using OpdrachtApiOntwikkeling.Models;
using OpdrachtApiOntwikkeling.Services;

namespace OpdrachtApiOntwikkeling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocations()
        {
            var locations = await _locationService.GetLocations();
            if (locations is null || locations.Count == 0)
            {
                return NotFound("No locations found.");
            }
            return Ok(locations);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location is null)
            {
                return NotFound($"Location with ID {id} not found.");
            }
            return Ok(location);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Location>>> SearchLocationsByName([FromQuery] string name)
        {
            var locations = await _locationService.SearchLocationsByName(name);
            if (locations is null || locations.Count == 0)
            {
                return NotFound($"No locations found with name containing '{name}'.");
            }
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult> AddLocation([FromBody] Location location)
        {
            await _locationService.AddLocation(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateLocation(int id, [FromBody] Location location)
        {
            if (id != location.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var updatedLocation = await _locationService.UpdateLocation(id, location);
            if (updatedLocation is null)
            {
                return NotFound($"Location with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            var existingLocation = await _locationService.GetLocationById(id);
            if (existingLocation is null)
            {
                return NotFound($"Location with ID {id} not found.");
            }
            await _locationService.DeleteLocation(id);
            return NoContent();
        }
    }
}