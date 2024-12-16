using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Models;
using System.Reflection.Emit;

namespace OpdrachtApiOntwikkeling.Data
{
    public static class SeedDataExtensions
    {
        public static void SeedAppData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Zul-Andra", Description = "A remote island known for its unique teleportation methods and fishing spots.", Image = "https://oldschool.runescape.wiki/images/Zul-Andra.png?bc8fb", BossId = 1 },
                new Location { Id = 2, Name = "Ungael", Description = "The lair of Vorkath, a powerful dragon found in the Wilderness.", Image = "https://oldschool.runescape.wiki/images/Ungael.png?2e330", BossId = 2 },
                new Location { Id = 3, Name = "Kraken Cove", Description = "A hidden cove where the Kraken resides, known for its treasure.", Image = "https://oldschool.runescape.wiki/images/Kraken_Cove.png?3be60", BossId = 3 },
                new Location { Id = 4, Name = "God Wars Dungeon", Description = "A battleground for gods, featuring powerful bosses and their minions.", Image = "https://oldschool.runescape.wiki/images/God_Wars_Dungeon_Entrance.png?8b0f5", BossId = 4 },
                new Location { Id = 5, Name = "Cerberus' Lair", Description = "A hellish cave home to Cerberus, guarded by hellhounds.", Image = "https://oldschool.runescape.wiki/images/Cerberus%27_Lair.png?75520", BossId = 5 },
                new Location { Id = 6, Name = "Waterbirth Island Dungeon", Description = "An underwater dungeon filled with fearsome creatures and guarded by Dagannoth kings.", Image = "https://oldschool.runescape.wiki/images/Waterbirth_Island_Dungeon_1.png?c9813", BossId = 6 },
                new Location { Id = 7, Name = "Morytania Spider Cave", Description = "A cave filled with dangerous spiders in the Morytania region.", Image = "https://oldschool.runescape.wiki/images/Morytania_Spider_Cave.png?74d5c", BossId = 7 },
                new Location { Id = 8, Name = "The Stranglewood", Description = "A thick forest known for its dangerous creatures and resources.", Image = "https://oldschool.runescape.wiki/images/The_Stranglewood.png?d5f29", BossId = 8 },
                new Location { Id = 9, Name = "The Scar", Description = "The home of the gnomes, located in the Tree Gnome Stronghold.", Image = "https://oldschool.runescape.wiki/images/The_Scar.png?61378", BossId = 9 },
                new Location { Id = 10, Name = "King Black Dragon Lair", Description = "A lair deep in the wilderness, home to the King Black Dragon.", Image = "https://oldschool.runescape.wiki/images/KBD_Lair_%28interior%29.png?35aa6", BossId = 10 }
            );

            modelBuilder.Entity<Boss>().HasData(
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
            );

            modelBuilder.Entity<UniqueItem>().HasData(
                new UniqueItem { Id = 1, Name = "Tanzanite fang", Price = 5784502, HighAlch = 66000, Image = "https://oldschool.runescape.wiki/images/Tanzanite_fang_detail.png?859ba" },
                new UniqueItem { Id = 2, Name = "Skeletal visage", Price = 13440000, HighAlch = 900000, Image = "https://oldschool.runescape.wiki/images/Skeletal_visage_detail.png?bccc7" },
                new UniqueItem { Id = 3, Name = "Kraken tentacle", Price = 561782, HighAlch = 50004, Image = "https://oldschool.runescape.wiki/images/Kraken_tentacle_detail.png?e5f2a" },
                new UniqueItem { Id = 4, Name = "Bandos chestplate", Price = 28918892, HighAlch = 174006, Image = "https://oldschool.runescape.wiki/images/Bandos_chestplate_detail.png?98028" },
                new UniqueItem { Id = 5, Name = "Primordial crystal", Price = 24435004, HighAlch = 27000, Image = "https://oldschool.runescape.wiki/images/Primordial_crystal_detail.png?9c62f" },
                new UniqueItem { Id = 6, Name = "Berserker ring", Price = 4460382, HighAlch = 6000, Image = "https://oldschool.runescape.wiki/images/Berserker_ring_detail.png?81f8b" },
                new UniqueItem { Id = 7, Name = "Araxyte fang", Price = 70399444, HighAlch = 120000, Image = "https://oldschool.runescape.wiki/images/Araxyte_fang_detail.png?43deb" },
                new UniqueItem { Id = 8, Name = "Executioner's axe head", Price = 370436553, HighAlch = 30000, Image = "https://oldschool.runescape.wiki/images/Executioner%27s_axe_head_detail.png?b410d" },
                new UniqueItem { Id = 9, Name = "Virtus robe top", Price = 66788559, HighAlch = 360000, Image = "https://oldschool.runescape.wiki/images/Virtus_robe_top_detail.png?b2b4a" },
                new UniqueItem { Id = 10, Name = "Draconic visage", Price = 4054769, HighAlch = 450000, Image = "https://oldschool.runescape.wiki/images/Draconic_visage_detail.png?6edab" }
            );
        }
    }
}
