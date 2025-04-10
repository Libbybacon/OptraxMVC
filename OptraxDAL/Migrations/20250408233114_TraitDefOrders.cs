using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class TraitDefOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasUOM",
                schema: "Grow",
                table: "TraitDefinitions",
                newName: "HasUom");

            migrationBuilder.AddColumn<int>(
                name: "GroupOrder",
                schema: "Grow",
                table: "TraitDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemOrder",
                schema: "Grow",
                table: "TraitDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupOrder",
                schema: "Grow",
                table: "TraitDefinitions");

            migrationBuilder.DropColumn(
                name: "ItemOrder",
                schema: "Grow",
                table: "TraitDefinitions");

            migrationBuilder.RenameColumn(
                name: "HasUom",
                schema: "Grow",
                table: "TraitDefinitions",
                newName: "HasUOM");
        }
    }
}
