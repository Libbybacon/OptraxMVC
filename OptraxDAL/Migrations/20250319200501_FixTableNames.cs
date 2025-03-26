using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Crop_CropID",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Cultivar_CultivarID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_RowLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Species_SpeciesID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Strains_StrainID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Variety_VarietyID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivar_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivar");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Batch_BatchID",
                schema: "Grow",
                table: "Planting");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Crop_CropID",
                schema: "Grow",
                table: "Planting");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Locations_LocationID",
                schema: "Grow",
                table: "Planting");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Crop_CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Planting_PlantingID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variety",
                schema: "Grow",
                table: "Variety");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planting",
                schema: "Grow",
                table: "Planting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivar",
                schema: "Grow",
                table: "Cultivar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crop",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "ObjectType",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.RenameTable(
                name: "Variety",
                schema: "Grow",
                newName: "Varieties",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Planting",
                schema: "Grow",
                newName: "Plantings",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Cultivar",
                schema: "Grow",
                newName: "Cultivars",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Crop",
                schema: "Grow",
                newName: "Crops",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Batch",
                schema: "Grow",
                newName: "Batches",
                newSchema: "Grow");

            migrationBuilder.RenameIndex(
                name: "IX_Planting_LocationID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Planting_CropID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Planting_BatchID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivar_SpeciesID",
                schema: "Grow",
                table: "Cultivars",
                newName: "IX_Cultivars_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_VarietyID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_VarietyID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_StrainID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_StrainID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_SpeciesID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_RowLocationID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_RowLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_RoomLocationID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_RoomLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_Name",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_GreenhouseLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_FieldLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_CultivarID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_CultivarID");

            migrationBuilder.RenameIndex(
                name: "IX_Batch_CropID",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Batch_BatchName",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_BatchName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Varieties",
                schema: "Grow",
                table: "Varieties",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plantings",
                schema: "Grow",
                table: "Plantings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivars",
                schema: "Grow",
                table: "Cultivars",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crops",
                schema: "Grow",
                table: "Crops",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batches",
                schema: "Grow",
                table: "Batches",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Crops_CropID",
                schema: "Grow",
                table: "Batches",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                column: "FieldLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops",
                column: "GreenhouseLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RoomLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RowLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Strains_StrainID",
                schema: "Grow",
                table: "Crops",
                column: "StrainID",
                principalSchema: "Grow",
                principalTable: "Strains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops",
                column: "VarietyID",
                principalSchema: "Grow",
                principalTable: "Varieties",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivars_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivars",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings",
                column: "BatchID",
                principalSchema: "Grow",
                principalTable: "Batches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Crops_CropID",
                schema: "Inventory",
                table: "Plants",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Plantings_PlantingID",
                schema: "Products",
                table: "ProductItems",
                column: "PlantingID",
                principalSchema: "Grow",
                principalTable: "Plantings",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Crops_CropID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Strains_StrainID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivars_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Crops_CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Plantings_PlantingID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Varieties",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plantings",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivars",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crops",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batches",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.RenameTable(
                name: "Varieties",
                schema: "Grow",
                newName: "Variety",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Plantings",
                schema: "Grow",
                newName: "Planting",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Cultivars",
                schema: "Grow",
                newName: "Cultivar",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Crops",
                schema: "Grow",
                newName: "Crop",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Batches",
                schema: "Grow",
                newName: "Batch",
                newSchema: "Grow");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_LocationID",
                schema: "Grow",
                table: "Planting",
                newName: "IX_Planting_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_CropID",
                schema: "Grow",
                table: "Planting",
                newName: "IX_Planting_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_BatchID",
                schema: "Grow",
                table: "Planting",
                newName: "IX_Planting_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivars_SpeciesID",
                schema: "Grow",
                table: "Cultivar",
                newName: "IX_Cultivar_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_VarietyID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_VarietyID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_StrainID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_StrainID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_SpeciesID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_RowLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_RowLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_RoomLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_RoomLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_Name",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_GreenhouseLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_FieldLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_CultivarID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_CultivarID");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CropID",
                schema: "Grow",
                table: "Batch",
                newName: "IX_Batch_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_BatchName",
                schema: "Grow",
                table: "Batch",
                newName: "IX_Batch_BatchName");

            migrationBuilder.AddColumn<string>(
                name: "ObjectType",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variety",
                schema: "Grow",
                table: "Variety",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planting",
                schema: "Grow",
                table: "Planting",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivar",
                schema: "Grow",
                table: "Cultivar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crop",
                schema: "Grow",
                table: "Crop",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                schema: "Grow",
                table: "Batch",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Crop_CropID",
                schema: "Grow",
                table: "Batch",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Cultivar_CultivarID",
                schema: "Grow",
                table: "Crop",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivar",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crop",
                column: "FieldLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop",
                column: "GreenhouseLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crop",
                column: "RoomLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_RowLocationID",
                schema: "Grow",
                table: "Crop",
                column: "RowLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Species_SpeciesID",
                schema: "Grow",
                table: "Crop",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Strains_StrainID",
                schema: "Grow",
                table: "Crop",
                column: "StrainID",
                principalSchema: "Grow",
                principalTable: "Strains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Variety_VarietyID",
                schema: "Grow",
                table: "Crop",
                column: "VarietyID",
                principalSchema: "Grow",
                principalTable: "Variety",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivar_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivar",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Batch_BatchID",
                schema: "Grow",
                table: "Planting",
                column: "BatchID",
                principalSchema: "Grow",
                principalTable: "Batch",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Crop_CropID",
                schema: "Grow",
                table: "Planting",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Locations_LocationID",
                schema: "Grow",
                table: "Planting",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Crop_CropID",
                schema: "Inventory",
                table: "Plants",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crop",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Planting_PlantingID",
                schema: "Products",
                table: "ProductItems",
                column: "PlantingID",
                principalSchema: "Grow",
                principalTable: "Planting",
                principalColumn: "ID");
        }
    }
}
