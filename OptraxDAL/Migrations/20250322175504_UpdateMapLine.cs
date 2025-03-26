using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMapLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                schema: "Map",
                table: "Lines",
                newName: "Weight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                schema: "Map",
                table: "Lines",
                newName: "Width");
        }
    }
}
