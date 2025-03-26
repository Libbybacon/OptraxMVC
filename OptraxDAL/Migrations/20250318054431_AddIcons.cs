using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectCategory",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                schema: "Map",
                table: "Points",
                type: "decimal(12,8)",
                precision: 12,
                scale: 8,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                schema: "Map",
                table: "Points",
                type: "decimal(12,8)",
                precision: 12,
                scale: 8,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "IconID",
                schema: "Map",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IconCollection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconCollection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IconCollection_IconCollection_ParentID",
                        column: x => x.ParentID,
                        principalTable: "IconCollection",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IconIconCollection",
                columns: table => new
                {
                    CollectionsID = table.Column<int>(type: "int", nullable: false),
                    IconsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconIconCollection", x => new { x.CollectionsID, x.IconsID });
                    table.ForeignKey(
                        name: "FK_IconIconCollection_IconCollection_CollectionsID",
                        column: x => x.CollectionsID,
                        principalTable: "IconCollection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IconIconCollection_Icons_IconsID",
                        column: x => x.IconsID,
                        principalSchema: "Map",
                        principalTable: "Icons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_IconID",
                schema: "Map",
                table: "Points",
                column: "IconID");

            migrationBuilder.CreateIndex(
                name: "IX_IconCollection_ParentID",
                table: "IconCollection",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_IconIconCollection_IconsID",
                table: "IconIconCollection",
                column: "IconsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Icons_IconID",
                schema: "Map",
                table: "Points",
                column: "IconID",
                principalSchema: "Map",
                principalTable: "Icons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Icons_IconID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropTable(
                name: "IconIconCollection");

            migrationBuilder.DropTable(
                name: "IconCollection");

            migrationBuilder.DropTable(
                name: "Icons",
                schema: "Map");

            migrationBuilder.DropIndex(
                name: "IX_Points_IconID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "IconID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                schema: "Map",
                table: "Points",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,8)",
                oldPrecision: 12,
                oldScale: 8);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                schema: "Map",
                table: "Points",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,8)",
                oldPrecision: 12,
                oldScale: 8);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ObjectCategory",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
