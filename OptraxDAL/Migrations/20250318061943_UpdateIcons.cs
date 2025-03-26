using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IconCollection_IconCollection_ParentID",
                table: "IconCollection");

            migrationBuilder.DropTable(
                name: "IconIconCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IconCollection",
                table: "IconCollection");

            migrationBuilder.RenameTable(
                name: "IconCollection",
                newName: "IconCollections",
                newSchema: "Map");

            migrationBuilder.RenameIndex(
                name: "IX_IconCollection_ParentID",
                schema: "Map",
                table: "IconCollections",
                newName: "IX_IconCollections_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IconCollections",
                schema: "Map",
                table: "IconCollections",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "IconCollectionMapIcon",
                schema: "Map",
                columns: table => new
                {
                    CollectionsID = table.Column<int>(type: "int", nullable: false),
                    IconsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconCollectionMapIcon", x => new { x.CollectionsID, x.IconsID });
                    table.ForeignKey(
                        name: "FK_IconCollectionMapIcon_IconCollections_CollectionsID",
                        column: x => x.CollectionsID,
                        principalSchema: "Map",
                        principalTable: "IconCollections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IconCollectionMapIcon_Icons_IconsID",
                        column: x => x.IconsID,
                        principalSchema: "Map",
                        principalTable: "Icons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IconCollectionMapIcon_IconsID",
                schema: "Map",
                table: "IconCollectionMapIcon",
                column: "IconsID");

            migrationBuilder.AddForeignKey(
                name: "FK_IconCollections_IconCollections_ParentID",
                schema: "Map",
                table: "IconCollections",
                column: "ParentID",
                principalSchema: "Map",
                principalTable: "IconCollections",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IconCollections_IconCollections_ParentID",
                schema: "Map",
                table: "IconCollections");

            migrationBuilder.DropTable(
                name: "IconCollectionMapIcon",
                schema: "Map");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IconCollections",
                schema: "Map",
                table: "IconCollections");

            migrationBuilder.RenameTable(
                name: "IconCollections",
                schema: "Map",
                newName: "IconCollection");

            migrationBuilder.RenameIndex(
                name: "IX_IconCollections_ParentID",
                table: "IconCollection",
                newName: "IX_IconCollection_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IconCollection",
                table: "IconCollection",
                column: "ID");

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
                name: "IX_IconIconCollection_IconsID",
                table: "IconIconCollection",
                column: "IconsID");

            migrationBuilder.AddForeignKey(
                name: "FK_IconCollection_IconCollection_ParentID",
                table: "IconCollection",
                column: "ParentID",
                principalTable: "IconCollection",
                principalColumn: "ID");
        }
    }
}
