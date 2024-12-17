using Microsoft.AspNetCore.Mvc;
using OpdrachtApiOntwikkeling.Models;
using OpdrachtApiOntwikkeling.Services;

namespace OpdrachtApiOntwikkeling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossesController : ControllerBase
    {
        private readonly IBossService _bossService;

        public BossesController(IBossService bossService)
        {
            _bossService = bossService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Boss>>> GetBosses()
        {
            var bosses = await _bossService.GetBosses();
            if (bosses is null || bosses.Count == 0)
            {
                return NotFound("No bosses found.");
            }
            return Ok(bosses);
        }

        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<Boss>> GetBossById(int id)
        {
            var boss = await _bossService.GetBossById(id);
            if (boss is null)
            {
                return NotFound($"Boss with ID {id} not found.");
            }
            return Ok(boss);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Boss>>> SearchBosses([FromQuery] string name)
        {
            var bosses = await _bossService.SearchBossesByName(name);
            if (bosses is null || bosses.Count == 0)
            {
                return NotFound($"No bosses found with name containing '{name}'.");
            }
            return Ok(bosses);
        }

        [HttpGet("search/combatLevel")]
        public async Task<ActionResult<List<Boss>>> GetBossesByCombatLevelRange([FromQuery] int minLevel, [FromQuery] int maxLevel)
        {
            var bosses = await _bossService.GetBossesByCombatLevelRange(minLevel, maxLevel);
            if (bosses is null || bosses.Count == 0)
            {
                return NotFound($"No bosses found in the combat level range {minLevel} - {maxLevel}.");
            }
            return Ok(bosses);
        }

        [HttpPost]
        public async Task<ActionResult> AddBoss([FromBody] Boss boss)
        {
            await _bossService.AddBoss(boss);
            return CreatedAtAction(nameof(GetBossById), new { id = boss.Id }, boss);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateBoss(int id, [FromBody] Boss boss)
        {
            var updatedBoss = await _bossService.UpdateBoss(id, boss);
            if (updatedBoss is null)
            {
                return NotFound($"Boss with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBoss(int id)
        {
            await _bossService.DeleteBoss(id);
            return NoContent();
        }
    }
}
