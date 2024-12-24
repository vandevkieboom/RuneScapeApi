using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OpdrachtApiOntwikkeling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniqueItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    price = table.Column<int>(type: "int", nullable: true),
                    high_alch = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hitpoints = table.Column<int>(type: "int", nullable: true),
                    combat_level = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unique_item_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bosses_UniqueItems_unique_item_id",
                        column: x => x.unique_item_id,
                        principalTable: "UniqueItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boss_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locations_Bosses_boss_id",
                        column: x => x.boss_id,
                        principalTable: "Bosses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "UniqueItems",
                columns: new[] { "id", "high_alch", "image", "name", "price" },
                values: new object[,]
                {
                    { 1, 66000, "https://oldschool.runescape.wiki/images/Tanzanite_fang_detail.png?859ba", "Tanzanite fang", 5784502 },
                    { 2, 900000, "https://oldschool.runescape.wiki/images/Skeletal_visage_detail.png?bccc7", "Skeletal visage", 13440000 },
                    { 3, 50004, "https://oldschool.runescape.wiki/images/Kraken_tentacle_detail.png?e5f2a", "Kraken tentacle", 561782 },
                    { 4, 174006, "https://oldschool.runescape.wiki/images/Bandos_chestplate_detail.png?98028", "Bandos chestplate", 28918892 },
                    { 5, 27000, "https://oldschool.runescape.wiki/images/Primordial_crystal_detail.png?9c62f", "Primordial crystal", 24435004 },
                    { 6, 6000, "https://oldschool.runescape.wiki/images/Berserker_ring_detail.png?81f8b", "Berserker ring", 4460382 },
                    { 7, 120000, "https://oldschool.runescape.wiki/images/Araxyte_fang_detail.png?43deb", "Araxyte fang", 70399444 },
                    { 8, 30000, "https://oldschool.runescape.wiki/images/Executioner%27s_axe_head_detail.png?b410d", "Executioner's axe head", 370436553 },
                    { 9, 360000, "https://oldschool.runescape.wiki/images/Virtus_robe_top_detail.png?b2b4a", "Virtus robe top", 66788559 },
                    { 10, 450000, "https://oldschool.runescape.wiki/images/Draconic_visage_detail.png?6edab", "Draconic visage", 4054769 }
                });

            migrationBuilder.InsertData(
                table: "Bosses",
                columns: new[] { "id", "combat_level", "hitpoints", "image", "name", "unique_item_id" },
                values: new object[,]
                {
                    { 1, 725, 500, "https://oldschool.runescape.wiki/images/Zulrah_%28serpentine%29.png?29a54", "Zulrah", 1 },
                    { 2, 732, 750, "https://oldschool.runescape.wiki/images/Vorkath.png?1ce3f", "Vorkath", 2 },
                    { 3, 291, 255, "https://oldschool.runescape.wiki/images/Cave_kraken.png?4612a", "Kraken", 3 },
                    { 4, 624, 255, "https://oldschool.runescape.wiki/images/General_Graardor.png?4dd90", "General Graardor", 4 },
                    { 5, 318, 650, "https://oldschool.runescape.wiki/images/Cerberus.png?47f4c", "Cerberus", 5 },
                    { 6, 303, 255, "https://oldschool.runescape.wiki/images/Dagannoth_Rex.png?a99a9", "Dagannoth Rex", 6 },
                    { 7, 890, 1020, "https://oldschool.runescape.wiki/images/Araxxor.png?35d2e", "Araxxor", 7 },
                    { 8, 1136, 1400, "https://oldschool.runescape.wiki/images/Vardorvis.png?48af8", "Vardorvis", 8 },
                    { 9, 1157, 2700, "https://oldschool.runescape.wiki/images/The_Leviathan.png?d588a", "The Leviathan", 9 },
                    { 10, 276, 255, "https://oldschool.runescape.wiki/images/King_Black_Dragon.png?d25f0", "King Black Dragon", 10 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "id", "boss_id", "description", "image", "name" },
                values: new object[,]
                {
                    { 1, 1, "A remote island known for its unique teleportation methods and fishing spots.", "https://oldschool.runescape.wiki/images/Zul-Andra.png?bc8fb", "Zul-Andra" },
                    { 2, 2, "The lair of Vorkath, a powerful dragon found in the Wilderness.", "https://oldschool.runescape.wiki/images/Ungael.png?2e330", "Ungael" },
                    { 3, 3, "A hidden cove where the Kraken resides, known for its treasure.", "https://oldschool.runescape.wiki/images/Kraken_Cove.png?3be60", "Kraken Cove" },
                    { 4, 4, "A battleground for gods, featuring powerful bosses and their minions.", "https://oldschool.runescape.wiki/images/God_Wars_Dungeon_Entrance.png?8b0f5", "God Wars Dungeon" },
                    { 5, 5, "A hellish cave home to Cerberus, guarded by hellhounds.", "https://oldschool.runescape.wiki/images/Cerberus%27_Lair.png?75520", "Cerberus' Lair" },
                    { 6, 6, "An underwater dungeon filled with fearsome creatures and guarded by Dagannoth kings.", "https://oldschool.runescape.wiki/images/Waterbirth_Island_Dungeon_1.png?c9813", "Waterbirth Island Dungeon" },
                    { 7, 7, "A cave filled with dangerous spiders in the Morytania region.", "https://oldschool.runescape.wiki/images/Morytania_Spider_Cave.png?74d5c", "Morytania Spider Cave" },
                    { 8, 8, "A thick forest known for its dangerous creatures and resources.", "https://oldschool.runescape.wiki/images/The_Stranglewood.png?d5f29", "The Stranglewood" },
                    { 9, 9, "The home of the gnomes, located in the Tree Gnome Stronghold.", "https://oldschool.runescape.wiki/images/The_Scar.png?61378", "The Scar" },
                    { 10, 10, "A lair deep in the wilderness, home to the King Black Dragon.", "https://oldschool.runescape.wiki/images/KBD_Lair_%28interior%29.png?35aa6", "King Black Dragon Lair" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_unique_item_id",
                table: "Bosses",
                column: "unique_item_id",
                unique: true,
                filter: "[unique_item_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_boss_id",
                table: "Locations",
                column: "boss_id",
                unique: true,
                filter: "[boss_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropTable(
                name: "UniqueItems");
        }
    }
}
