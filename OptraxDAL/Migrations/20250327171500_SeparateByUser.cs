using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class SeparateByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Products",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MapID",
                schema: "Map",
                table: "MapObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Maps",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maps_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_UserID",
                schema: "Grow",
                table: "Varieties",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Strains_UserID",
                schema: "Grow",
                table: "Strains",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_UserID",
                schema: "Inventory",
                table: "StockItems",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_UserID",
                schema: "Grow",
                table: "Species",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_UserID",
                schema: "Inventory",
                table: "SalesOrders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UserID",
                schema: "Inventory",
                table: "Resources",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserID",
                schema: "Products",
                table: "Products",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_UserID",
                schema: "Products",
                table: "ProductBatches",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Plantings_UserID",
                schema: "Grow",
                table: "Plantings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MapObjects_MapID",
                schema: "Map",
                table: "MapObjects",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_MapObjects_UserID",
                schema: "Map",
                table: "MapObjects",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserID",
                schema: "Admin",
                table: "Locations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivars_UserID",
                schema: "Grow",
                table: "Cultivars",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_UserID",
                schema: "Grow",
                table: "Crops",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserID",
                schema: "Admin",
                table: "Businesses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_UserID",
                schema: "Grow",
                table: "Batches",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserID",
                schema: "Admin",
                table: "Address",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_UserID",
                schema: "Map",
                table: "Maps",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserID",
                schema: "Admin",
                table: "Address",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_AspNetUsers_UserID",
                schema: "Grow",
                table: "Batches",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_UserID",
                schema: "Admin",
                table: "Businesses",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_AspNetUsers_UserID",
                schema: "Grow",
                table: "Crops",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivars_AspNetUsers_UserID",
                schema: "Grow",
                table: "Cultivars",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_UserID",
                schema: "Admin",
                table: "Locations",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapObjects_AspNetUsers_UserID",
                schema: "Map",
                table: "MapObjects",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapObjects_Maps_MapID",
                schema: "Map",
                table: "MapObjects",
                column: "MapID",
                principalSchema: "Map",
                principalTable: "Maps",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_AspNetUsers_UserID",
                schema: "Grow",
                table: "Plantings",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserID",
                schema: "Products",
                table: "ProductBatches",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                schema: "Products",
                table: "Products",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Resources",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserID",
                schema: "Inventory",
                table: "SalesOrders",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_AspNetUsers_UserID",
                schema: "Grow",
                table: "Species",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_AspNetUsers_UserID",
                schema: "Inventory",
                table: "StockItems",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strains_AspNetUsers_UserID",
                schema: "Grow",
                table: "Strains",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Varieties_AspNetUsers_UserID",
                schema: "Grow",
                table: "Varieties",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_AspNetUsers_UserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_UserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_AspNetUsers_UserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivars_AspNetUsers_UserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_UserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_AspNetUsers_UserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_Maps_MapID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_AspNetUsers_UserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_AspNetUsers_UserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_AspNetUsers_UserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Strains_AspNetUsers_UserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Varieties_AspNetUsers_UserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropTable(
                name: "Maps",
                schema: "Map");

            migrationBuilder.DropIndex(
                name: "IX_Varieties_UserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Strains_UserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_UserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_Species_UserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_UserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_Resources_UserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductBatches_UserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropIndex(
                name: "IX_Plantings_UserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropIndex(
                name: "IX_MapObjects_MapID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropIndex(
                name: "IX_MapObjects_UserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Cultivars_UserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropIndex(
                name: "IX_Crops_UserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_UserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Batches_UserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "MapID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
