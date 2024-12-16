using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Data;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BossesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddBoss([FromBody] Boss boss)
        {
            _context.Bosses.Add(boss);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBossById), new { id = boss.Id }, boss);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Boss>>> GetBosses()
        {
            var bosses = await _context.Bosses.ToListAsync();
            if (bosses is null || !bosses.Any())
            {
                return NotFound("No bosses found.");
            }
            return Ok(bosses);
        }

        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<Boss>> GetBossById(int id)
        {
            var boss = await _context.Bosses.FindAsync(id);
            if (boss is null)
            {
                return NotFound($"Boss with ID {id} not found.");
            }
            return Ok(boss);
        }

        [HttpGet("{id:int}/image")]
        public async Task<ActionResult<Boss>> GetBossImage(int id)
        {
            var boss = await _context.Bosses.FindAsync(id);
            if (boss is null)
            {
                return NotFound($"Boss with ID {id} not found.");
            }
            return Ok(boss.Image);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Boss>>> SearchBosses([FromQuery] string name)
        {
            var bosses = await _context.Bosses
                .Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
            if (bosses is null || !bosses.Any())
            {
                return NotFound($"No bosses found with name containing '{name}'.");
            }
            return Ok(bosses);
        }

        [HttpGet("search/combatLevel")]
        public async Task<ActionResult<List<Boss>>> GetBossesByCombatLevelRange([FromQuery] int minLevel, [FromQuery] int maxLevel)
        {
            var bosses = await _context.Bosses
                .Where(b => b.CombatLevel >= minLevel && b.CombatLevel <= maxLevel)
                .ToListAsync();
            if (bosses is null || !bosses.Any())
            {
                return NotFound($"No bosses found in the combat level range {minLevel} - {maxLevel}.");
            }
            return Ok(bosses);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateBoss(int id, [FromBody] Boss boss)
        {
            if (id != boss.Id)
            {
                return BadRequest("Boss ID mismatch.");
            }
            _context.Entry(boss).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bosses.Any(e => e.Id == id))
                {
                    return NotFound($"Boss with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBoss(int id)
        {
            var boss = await _context.Bosses.FindAsync(id);
            if (boss is null)
            {
                return NotFound($"Boss with ID {id} not found.");
            }
            _context.Bosses.Remove(boss);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
