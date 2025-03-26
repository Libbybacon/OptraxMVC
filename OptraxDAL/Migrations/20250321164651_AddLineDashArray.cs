using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLineDashArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DashArray",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DashArray",
                schema: "Map",
                table: "Lines");
        }
    }
}
