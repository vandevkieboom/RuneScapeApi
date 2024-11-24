using Microsoft.AspNetCore.Mvc;
using OpdrachtApiOntwikkelingDeel1.Models;
using OpdrachtApiOntwikkelingDeel1.Services;

namespace OpdrachtApiOntwikkelingDeel1.Controllers
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

        [HttpPost]
        public async Task<ActionResult> AddUniqueItem([FromBody] UniqueItem uniqueItem)
        {
            await _uniqueItemService.AddUniqueItem(uniqueItem);
            return CreatedAtAction(nameof(GetUniqueItemById), new { id = uniqueItem.Id }, uniqueItem);
        }

        [HttpGet]
        public async Task<ActionResult<List<UniqueItem>>> GetUniqueItems()
        {
            var uniqueItems = await _uniqueItemService.GetUniqueItems();
            return Ok(uniqueItems);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UniqueItem>> GetUniqueItemById(int id)
        {
            var uniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (uniqueItem is null)
            {
                return NotFound();
            }
            return Ok(uniqueItem);
        }

        [HttpGet("{id:int}/image")]
        public async Task<ActionResult<UniqueItem>> GetUniqueItemImage(int id)
        {
            var uniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (uniqueItem is null)
            {
                return NotFound();
            }
            return Ok(uniqueItem.Image);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByName([FromQuery] string name)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByName(name);
            if (uniqueItems == null || uniqueItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(uniqueItems);
        }

        [HttpGet("search/price")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByPriceRange([FromQuery] int minPrice, [FromQuery] int maxPrice)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByPriceRange(minPrice, maxPrice);
            if (uniqueItems == null || uniqueItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(uniqueItems);
        }

        [HttpGet("search/highalch")]
        public async Task<ActionResult<List<UniqueItem>>> SearchUniqueItemsByHighAlchRange([FromQuery] int minHighAlch, [FromQuery] int maxHighAlch)
        {
            var uniqueItems = await _uniqueItemService.SearchUniqueItemsByHighAlchRange(minHighAlch, maxHighAlch);
            if (uniqueItems == null || uniqueItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(uniqueItems);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUniqueItem(int id, [FromBody] UniqueItem uniqueItem)
        {
            if (id != uniqueItem.Id)
            {
                return BadRequest();
            }

            var existingUniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (existingUniqueItem is null)
            {
                return NotFound();
            }
            var updatedUniqueItem = await _uniqueItemService.UpdateUniqueItem(id, uniqueItem);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUniqueItem(int id)
        {
            var existingUniqueItem = await _uniqueItemService.GetUniqueItemById(id);
            if (existingUniqueItem is null)
            {
                return NotFound();
            }
            await _uniqueItemService.DeleteUniqueItem(id);
            return NoContent();
        }
    }
}
