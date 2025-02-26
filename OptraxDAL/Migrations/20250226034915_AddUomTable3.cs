using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUomTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "System",
                table: "UOMs");

            migrationBuilder.AddColumn<decimal>(
                name: "PerQuantity",
                table: "UOMs",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerQuantity",
                table: "UOMs");

            migrationBuilder.AddColumn<string>(
                name: "System",
                table: "UOMs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
