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

        [HttpPost]
        public async Task<ActionResult> AddLocation([FromBody] Location location)
        {
            await _locationService.AddLocation(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocations()
        {
            var locations = await _locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location is null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpGet("{id:int}/image")]
        public async Task<ActionResult<Location>> GetLocationImage(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location is null)
            {
                return NotFound();
            }
            return Ok(location.Image);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Location>>> SearchLocationsByName([FromQuery] string name)
        {
            var locations = await _locationService.SearchLocationsByName(name);
            if (locations == null || locations.Count == 0)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateLocation(int id, [FromBody] Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var existingLocation = await _locationService.GetLocationById(id);
            if (existingLocation is null)
            {
                return NotFound();
            }
            var updatedLocation = await _locationService.UpdateLocation(id, location);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            var existingLocation = await _locationService.GetLocationById(id);
            if (existingLocation is null)
            {
                return NotFound();
            }
            await _locationService.DeleteLocation(id);
            return NoContent();
        }
    }
}
