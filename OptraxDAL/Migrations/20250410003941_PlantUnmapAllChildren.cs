using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantUnmapAllChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Plants_PlantId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_PlantId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantId",
                schema: "Grow",
                table: "Plants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                schema: "Grow",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantId",
                schema: "Grow",
                table: "Plants",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Plants_PlantId",
                schema: "Grow",
                table: "Plants",
                column: "PlantId",
                principalSchema: "Grow",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
