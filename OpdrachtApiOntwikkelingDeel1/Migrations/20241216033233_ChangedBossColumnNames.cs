using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpdrachtApiOntwikkeling.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBossColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bosses",
                newName: "example");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bosses",
                newName: "boss_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "example",
                table: "Bosses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "boss_id",
                table: "Bosses",
                newName: "Id");
        }
    }
}
