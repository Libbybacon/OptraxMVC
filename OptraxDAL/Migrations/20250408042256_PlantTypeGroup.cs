using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantTypeGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                schema: "Grow",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeGroups",
                schema: "Grow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroups", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Plants_PlantId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "TypeGroups",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_Plants_PlantId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantId",
                schema: "Grow",
                table: "Plants");
        }
    }
}
