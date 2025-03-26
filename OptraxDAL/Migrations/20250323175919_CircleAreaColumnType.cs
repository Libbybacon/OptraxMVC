using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class CircleAreaColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<Polygon>(
            //    name: "Area",
            //    schema: "Map",
            //    table: "Circles",
            //    type: "geometry",
            //    nullable: true,
            //    oldClrType: typeof(Polygon),
            //    oldType: "geography",
            //    oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<Polygon>(
            //    name: "Area",
            //    schema: "Map",
            //    table: "Circles",
            //    type: "geography",
            //    nullable: true,
            //    oldClrType: typeof(Polygon),
            //    oldType: "geometry",
            //    oldNullable: true);
        }
    }
}
