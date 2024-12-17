using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Data;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public class BossServiceDb : IBossService
    {
        private readonly AppDbContext _context;

        public BossServiceDb(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Boss>> GetBosses()
        {
            return await _context.Bosses
                .Include(boss => boss.UniqueItem)
                .ToListAsync();
        }

        public async Task<Boss?> GetBossById(int id)
        {
            return await _context.Bosses
                .Include(boss => boss.UniqueItem)
                .FirstOrDefaultAsync(boss => boss.Id == id);
        }

        public async Task<List<Boss>> SearchBossesByName(string name)
        {
            var bosses = await _context.Bosses
                .Include(boss => boss.UniqueItem)
                .ToListAsync();
            return bosses
                .Where(boss => boss.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task<List<Boss>> GetBossesByCombatLevelRange(int minLevel, int maxLevel)
        {
            return await _context.Bosses
                .Include(boss => boss.UniqueItem)
                .Where(boss => boss.CombatLevel >= minLevel && boss.CombatLevel <= maxLevel)
                .ToListAsync();
        }

        public async Task AddBoss(Boss boss)
        {
            _context.Bosses.Add(boss);
            await _context.SaveChangesAsync();
        }

        public async Task<Boss?> UpdateBoss(int id, Boss updatedBoss)
        {
            var boss = await _context.Bosses
                .FirstOrDefaultAsync(b => b.Id == id);
            if (boss is not null)
            {
                boss.Name = updatedBoss.Name;
                boss.Hitpoints = updatedBoss.Hitpoints;
                boss.CombatLevel = updatedBoss.CombatLevel;
                boss.Image = updatedBoss.Image;
                boss.UniqueItemId = updatedBoss.UniqueItemId;
                boss.UniqueItem = updatedBoss.UniqueItem;

                await _context.SaveChangesAsync();
            }
            return boss;
        }

        public async Task DeleteBoss(int id)
        {
            var boss = await _context.Bosses
                .FirstOrDefaultAsync(b => b.Id == id);
            if (boss is not null)
            {
                _context.Bosses.Remove(boss);
                await _context.SaveChangesAsync();
            }
        }
    }
}