﻿using OpdrachtApiOntwikkelingDeel1.Models;

namespace OpdrachtApiOntwikkelingDeel1.Services
{
    public class BossService : IBossService
    {
        private static readonly List<Boss> _allBosses = new()
        {
            new Boss { Id = 1, Name = "Zulrah", Hitpoints = 500, CombatLevel = 725, Image = "https://oldschool.runescape.wiki/images/Zulrah_%28serpentine%29.png?29a54", UniqueItemId = 1 },
            new Boss { Id = 2, Name = "Vorkath", Hitpoints = 750, CombatLevel = 732, Image = "https://oldschool.runescape.wiki/images/Vorkath.png?1ce3f", UniqueItemId = 2 },
            new Boss { Id = 3, Name = "Kraken", Hitpoints = 255, CombatLevel = 291, Image = "https://oldschool.runescape.wiki/images/Cave_kraken.png?4612a", UniqueItemId = 3 },
            new Boss { Id = 4, Name = "General Graardor", Hitpoints = 255, CombatLevel = 624, Image = "https://oldschool.runescape.wiki/images/General_Graardor.png?4dd90", UniqueItemId = 4 },
            new Boss { Id = 5, Name = "Cerberus", Hitpoints = 650, CombatLevel = 318, Image = "https://oldschool.runescape.wiki/images/Cerberus.png?47f4c", UniqueItemId = 5 },
            new Boss { Id = 6, Name = "Dagannoth Rex", Hitpoints = 255, CombatLevel = 303, Image = "https://oldschool.runescape.wiki/images/Dagannoth_Rex.png?a99a9", UniqueItemId = 6 },
            new Boss { Id = 7, Name = "Araxxor", Hitpoints = 1020, CombatLevel = 890, Image = "https://oldschool.runescape.wiki/images/Araxxor.png?35d2e", UniqueItemId = 7 },
            new Boss { Id = 8, Name = "Vardorvis", Hitpoints = 1400, CombatLevel = 1136, Image = "https://oldschool.runescape.wiki/images/Vardorvis.png?48af8", UniqueItemId = 8 },
            new Boss { Id = 9, Name = "The Leviathan", Hitpoints = 2700, CombatLevel = 1157, Image = "https://oldschool.runescape.wiki/images/The_Leviathan.png?d588a", UniqueItemId = 9 },
            new Boss { Id = 10, Name = "King Black Dragon", Hitpoints = 255, CombatLevel = 276, Image = "https://oldschool.runescape.wiki/images/King_Black_Dragon.png?d25f0", UniqueItemId = 10 }
        };

        public Task AddBoss(Boss boss)
        {
            _allBosses.Add(boss);
            return Task.CompletedTask;
        }

        public Task<List<Boss>> GetBosses()
        {
            return Task.FromResult(_allBosses);
        }

        public Task<Boss?> GetBossById(int id)
        {
            var boss = _allBosses.FirstOrDefault(boss => id == boss.Id);
            return Task.FromResult(boss);
        }

        public Task<List<Boss>> SearchBossesByName(string name)
        {
            var bosses = _allBosses
                .Where(boss => boss.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Task.FromResult(bosses);
        }

        public Task<List<Boss>> GetBossesByCombatLevelRange(int minLevel, int maxLevel)
        {
            var bosses = _allBosses
                .Where(boss => boss.CombatLevel >= minLevel && boss.CombatLevel <= maxLevel)
                .ToList();
            return Task.FromResult(bosses);
        }

        public Task<Boss?> UpdateBoss(int id, Boss updatedBoss)
        {
            var boss = _allBosses.FirstOrDefault(b => b.Id == id);
            if (boss != null)
            {
                boss.Name = updatedBoss.Name;
                boss.Hitpoints = updatedBoss.Hitpoints;
                boss.CombatLevel = updatedBoss.CombatLevel;
                boss.Image = updatedBoss.Image;
                boss.UniqueItemId = updatedBoss.UniqueItemId;
                boss.UniqueItem = updatedBoss.UniqueItem;
            }
            return Task.FromResult(boss);
        }

        public Task DeleteBoss(int id)
        {
            var boss = _allBosses.FirstOrDefault(b => b.Id == id);
            if (boss != null)
            {
                _allBosses.Remove(boss);
            }
            return Task.CompletedTask;
        }
    }
}