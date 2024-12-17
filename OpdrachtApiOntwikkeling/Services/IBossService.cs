using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Services
{
    public interface IBossService
    {
        public Task<List<Boss>> GetBosses();
        public Task<Boss?> GetBossById(int id);
        public Task<List<Boss>> SearchBossesByName(string name);
        public Task<List<Boss>> GetBossesByCombatLevelRange(int minLevel, int maxLevel);
        public Task AddBoss(Boss boss);
        public Task<Boss?> UpdateBoss(int id, Boss updatedBoss);
        public Task DeleteBoss(int id);
    }
}