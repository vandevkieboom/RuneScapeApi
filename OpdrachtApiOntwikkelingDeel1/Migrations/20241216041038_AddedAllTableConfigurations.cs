using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtApiOntwikkeling.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllTableConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bosses_UniqueItems_UniqueItemId",
                table: "Bosses");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Bosses_BossId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_BossId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "UniqueItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UniqueItems",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "UniqueItems",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "HighAlch",
                table: "UniqueItems",
                newName: "high_alch");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UniqueItems",
                newName: "unique_item_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Locations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Locations",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Locations",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "BossId",
                table: "Locations",
                newName: "boss_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Bosses",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Hitpoints",
                table: "Bosses",
                newName: "hitpoints");

            migrationBuilder.RenameColumn(
                name: "example",
                table: "Bosses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UniqueItemId",
                table: "Bosses",
                newName: "unique_item_id");

            migrationBuilder.RenameColumn(
                name: "CombatLevel",
                table: "Bosses",
                newName: "combat_level");

            migrationBuilder.RenameIndex(
                name: "IX_Bosses_UniqueItemId",
                table: "Bosses",
                newName: "IX_Bosses_unique_item_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Bosses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_boss_id",
                table: "Locations",
                column: "boss_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bosses_UniqueItems_unique_item_id",
                table: "Bosses",
                column: "unique_item_id",
                principalTable: "UniqueItems",
                principalColumn: "unique_item_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Bosses_boss_id",
                table: "Locations",
                column: "boss_id",
                principalTable: "Bosses",
                principalColumn: "boss_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bosses_UniqueItems_unique_item_id",
                table: "Bosses");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Bosses_boss_id",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_boss_id",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "UniqueItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UniqueItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "UniqueItems",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "high_alch",
                table: "UniqueItems",
                newName: "HighAlch");

            migrationBuilder.RenameColumn(
                name: "unique_item_id",
                table: "UniqueItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Locations",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Locations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "boss_id",
                table: "Locations",
                newName: "BossId");

            migrationBuilder.RenameColumn(
                name: "location_id",
                table: "Locations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Bosses",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "hitpoints",
                table: "Bosses",
                newName: "Hitpoints");

            migrationBuilder.RenameColumn(
                name: "unique_item_id",
                table: "Bosses",
                newName: "UniqueItemId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Bosses",
                newName: "example");

            migrationBuilder.RenameColumn(
                name: "combat_level",
                table: "Bosses",
                newName: "CombatLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Bosses_unique_item_id",
                table: "Bosses",
                newName: "IX_Bosses_UniqueItemId");

            migrationBuilder.AlterColumn<string>(
                name: "example",
                table: "Bosses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BossId",
                table: "Locations",
                column: "BossId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bosses_UniqueItems_UniqueItemId",
                table: "Bosses",
                column: "UniqueItemId",
                principalTable: "UniqueItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Bosses_BossId",
                table: "Locations",
                column: "BossId",
                principalTable: "Bosses",
                principalColumn: "boss_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
