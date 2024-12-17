using Microsoft.AspNetCore.Mvc;
using OpdrachtApiOntwikkeling.Models;
using OpdrachtApiOntwikkeling.Services;

namespace OpdrachtApiOntwikkeling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniqueItemsController : ControllerBase
    {
        private readonly IUniqueItemService _uniqueItemService;

        public UniqueItemsController(IUniqueItemService uniqueItemService)
        {
            _uniqueItemService = uniqueItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UniqueItem>>> GetUniqueItems()
        {
            var uniqueItems = await _uniqueItemService.GetUniqueItems();
            if (uniqueItems is null || uniqueItems.Count == 0)
            {
                return NotFound("No unique items found.");
            }
            return Ok(uniqueItems);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UniqueItem>> GetUniqueItemById(int id)
        {
            var uniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (uniqueItem is null)
            {
                return NotFound($"Unique item with ID {id} not found.");
            }
            return Ok(uniqueItem);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByName([FromQuery] string name)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByName(name);
            if (uniqueItems is null || uniqueItems.Count == 0)
            {
                return NotFound($"No unique items found with name containing '{name}'.");
            }
            return Ok(uniqueItems);
        }

        [HttpGet("search/price")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByPriceRange([FromQuery] int minPrice, [FromQuery] int maxPrice)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByPriceRange(minPrice, maxPrice);
            if (uniqueItems is null || uniqueItems.Count == 0)
            {
                return NotFound($"No unique items found in the price range {minPrice} - {maxPrice}.");
            }
            return Ok(uniqueItems);
        }

        [HttpGet("search/highalch")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByHighAlchRange([FromQuery] int minHighAlch, [FromQuery] int maxHighAlch)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByHighAlchRange(minHighAlch, maxHighAlch);
            if (uniqueItems is null || uniqueItems.Count == 0)
            {
                return NotFound($"No unique items found in the high alch range {minHighAlch} - {maxHighAlch}.");
            }
            return Ok(uniqueItems);
        }

        [HttpPost]
        public async Task<ActionResult> AddUniqueItem([FromBody] UniqueItem uniqueItem)
        {
            await _uniqueItemService.AddUniqueItem(uniqueItem);
            return CreatedAtAction(nameof(GetUniqueItemById), new { id = uniqueItem.Id }, uniqueItem);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUniqueItem(int id, [FromBody] UniqueItem uniqueItem)
        {
            if (id != uniqueItem.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var updatedUniqueItem = await _uniqueItemService.UpdateUniqueItem(id, uniqueItem);
            if (updatedUniqueItem is null)
            {
                return NotFound($"Unique item with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUniqueItem(int id)
        {
            var existingUniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (existingUniqueItem is null)
            {
                return NotFound($"Unique item with ID {id} not found.");
            }
            await _uniqueItemService.DeleteUniqueItem(id);
            return NoContent();
        }
    }
}