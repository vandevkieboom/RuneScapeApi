using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtApiOntwikkeling.Migrations
{
    /// <inheritdoc />
    public partial class AddedBossConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bosses_UniqueItemId",
                table: "Bosses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bosses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_UniqueItemId",
                table: "Bosses",
                column: "UniqueItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bosses_UniqueItemId",
                table: "Bosses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bosses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_UniqueItemId",
                table: "Bosses",
                column: "UniqueItemId");
        }
    }
}
