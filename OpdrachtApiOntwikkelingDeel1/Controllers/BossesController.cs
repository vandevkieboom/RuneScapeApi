using Microsoft.AspNetCore.Mvc;
using OpdrachtApiOntwikkelingDeel1.Models;
using OpdrachtApiOntwikkelingDeel1.Services;

namespace OpdrachtApiOntwikkelingDeel1.Controllers
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

        [HttpPost]
        public async Task<ActionResult> AddBoss([FromBody] Boss boss)
        {
            await _bossService.AddBoss(boss);
            return CreatedAtAction(nameof(GetBossById), new { id = boss.Id }, boss);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Boss>>> GetBosses()
        {
            var bosses = await _bossService.GetBosses();
            return Ok(bosses);
        }

        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<Boss>> GetBossById(int id)
        {
            var boss = await _bossService.GetBossById(id);
            if (boss is null)
            {
                return NotFound();
            }
            return Ok(boss);
        }

        [HttpGet("{id:int}/image")]
        public async Task<ActionResult<Boss>> GetBossImage(int id)
        {
            var boss = await _bossService.GetBossById(id);
            if (boss is null)
            {
                return NotFound();
            }
            return Ok(boss.Image);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Boss>>> SearchBosses([FromQuery] string name)
        {
            var bosses = await _bossService.SearchBossesByName(name);
            if (bosses == null || bosses.Count == 0)
            {
                return NotFound();
            }
            return Ok(bosses);
        }

        [HttpGet("search/combatLevel")]
        public async Task<ActionResult<List<Boss>>> GetBossesByCombatLevelRange([FromQuery] int minLevel, [FromQuery] int maxLevel)
        {
            var bosses = await _bossService.GetBossesByCombatLevelRange(minLevel, maxLevel);
            if (bosses == null || bosses.Count == 0)
            {
                return NotFound();
            }
            return Ok(bosses);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateBoss(int id, [FromBody] Boss boss)
        {
            if (id != boss.Id)
            {
                return BadRequest();
            }

            var existingBoss = await _bossService.GetBossById(id);
            if (existingBoss is null)
            {
                return NotFound();
            }
            var updatedBoss = await _bossService.UpdateBoss(id, boss);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBoss(int id)
        {
            var existingBoss = await _bossService.GetBossById(id);
            if (existingBoss is null)
            {
                return NotFound();
            }
            await _bossService.DeleteBoss(id);
            return NoContent();
        }
    }
}
