using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantsAndProfilesAndTraits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Businesses_BusinessID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_AspNetUsers_UserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Crops_CropID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_UserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentID",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Circles_MapObjects_ID",
                schema: "Map",
                table: "Circles");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_StockItems_ID",
                schema: "Inventory",
                table: "Consumables");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_AspNetUsers_UserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
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
                name: "FK_Durables_StockItems_ID",
                schema: "Inventory",
                table: "Durables");

            migrationBuilder.DropForeignKey(
                name: "FK_IconCollections_IconCollections_ParentID",
                schema: "Admin",
                table: "IconCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_IconIconCollection_IconCollections_CollectionsID",
                schema: "Admin",
                table: "IconIconCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_IconIconCollection_Icons_IconsID",
                schema: "Admin",
                table: "IconIconCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_Lines_MapObjects_ID",
                schema: "Map",
                table: "Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_UserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_BusinessID1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locations_ParentID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationStockItem_Locations_LocationsID",
                table: "LocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationStockItem_StockItems_StockItemsID",
                table: "LocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_AspNetUsers_UserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_Maps_MapID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_AspNetUsers_UserID",
                schema: "Map",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingPatterns_AspNetUsers_UserID",
                schema: "Grow",
                table: "PlantingPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_AspNetUsers_UserID",
                schema: "Grow",
                table: "Plantings");

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
                name: "FK_PlantingSections_AspNetUsers_UserID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_MapObjects_MapObjectID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_PlantingPatterns_PatternID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_PlantingSections_ParentID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_Plantings_PlantingID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Crops_CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Plants_ParentID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_StockItems_ID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Strains_StrainID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Icons_IconID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_MapObjects_ID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Polygons_MapObjects_ID",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatches_Products_ProductID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Locations_LocationID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Plantings_PlantingID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_ProductBatches_BatchID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderStockItem_PurchaseOrder_PurchaseOrdersID",
                table: "PurchaseOrderStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderStockItem_StockItems_ItemsID",
                table: "PurchaseOrderStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Categories_CategoryID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_AspNetUsers_UserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Resources_ResourceID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_AspNetUsers_ManagerID",
                schema: "Inventory",
                table: "TransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferID",
                schema: "Inventory",
                table: "TransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_DestinationID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_OriginID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_StockItems_StockItemID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "Cultivars",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "PlantEvents",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "StrainRelationships");

            migrationBuilder.DropTable(
                name: "Varieties",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Lights",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Strains",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Species",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_PlantingSections_MapObjectID",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Crops_CultivarID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_StrainID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_VarietyID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Plants_CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "StrainID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "VarietyID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Phase",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "SpeciesID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "TrackingID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "Plants",
                schema: "Inventory",
                newName: "Plants",
                newSchema: "Grow");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Inventory",
                table: "Transfers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "StockItemID",
                schema: "Inventory",
                table: "Transfers",
                newName: "StockItemId");

            migrationBuilder.RenameColumn(
                name: "OriginID",
                schema: "Inventory",
                table: "Transfers",
                newName: "OriginId");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                schema: "Inventory",
                table: "Transfers",
                newName: "DestinationId");

            migrationBuilder.RenameColumn(
                name: "ApprovalID",
                schema: "Inventory",
                table: "Transfers",
                newName: "ApprovalId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_UserID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_StockItemID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_StockItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_OriginID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_DestinationId");

            migrationBuilder.RenameColumn(
                name: "TransferID",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "TransferId");

            migrationBuilder.RenameColumn(
                name: "ManagerID",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferApprovals_TransferID",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "IX_TransferApprovals_TransferId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferApprovals_ManagerID",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "IX_TransferApprovals_ManagerId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Inventory",
                table: "StockItems",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ResourceID",
                schema: "Inventory",
                table: "StockItems",
                newName: "ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_UserID",
                schema: "Inventory",
                table: "StockItems",
                newName: "IX_StockItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_ResourceID",
                schema: "Inventory",
                table: "StockItems",
                newName: "IX_StockItems_ResourceId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrders_UserID",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "IX_SalesOrders_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Inventory",
                table: "Resources",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                schema: "Inventory",
                table: "Resources",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                schema: "Inventory",
                table: "Resources",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_UserID",
                schema: "Inventory",
                table: "Resources",
                newName: "IX_Resources_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_CategoryID",
                schema: "Inventory",
                table: "Resources",
                newName: "IX_Resources_CategoryId");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrdersID",
                table: "PurchaseOrderStockItem",
                newName: "PurchaseOrdersId");

            migrationBuilder.RenameColumn(
                name: "ItemsID",
                table: "PurchaseOrderStockItem",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderStockItem_PurchaseOrdersID",
                table: "PurchaseOrderStockItem",
                newName: "IX_PurchaseOrderStockItem_PurchaseOrdersId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                schema: "Products",
                table: "PurchaseOrder",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Products",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserID",
                schema: "Products",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.RenameColumn(
                name: "SalesOrderID",
                schema: "Products",
                table: "ProductItems",
                newName: "SalesOrderId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                schema: "Products",
                table: "ProductItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PlantingID",
                schema: "Products",
                table: "ProductItems",
                newName: "PlantingId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                schema: "Products",
                table: "ProductItems",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                schema: "Products",
                table: "ProductItems",
                newName: "BatchId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_SalesOrderID",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_ProductID",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_PlantingID",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_PlantingId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_LocationID",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_BatchID",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_BatchId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Products",
                table: "ProductBatches",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                schema: "Products",
                table: "ProductBatches",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBatches_UserID",
                schema: "Products",
                table: "ProductBatches",
                newName: "IX_ProductBatches_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBatches_ProductID",
                schema: "Products",
                table: "ProductBatches",
                newName: "IX_ProductBatches_ProductId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                schema: "Map",
                table: "Polygons",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                schema: "Map",
                table: "Points",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "IconID",
                schema: "Map",
                table: "Points",
                newName: "IconId");

            migrationBuilder.RenameColumn(
                name: "IconCollectionID",
                schema: "Map",
                table: "Points",
                newName: "IconCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_IconID",
                schema: "Map",
                table: "Points",
                newName: "IX_Points_IconId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PlantingID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "PlantingId");

            migrationBuilder.RenameColumn(
                name: "PatternID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "PatternId");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "MapObjectID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "MapObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_UserID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_PlantingID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_PlantingId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_PatternID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_PatternId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_ParentID",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_ParentId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Grow",
                table: "Plantings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                schema: "Grow",
                table: "Plantings",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "CropID",
                schema: "Grow",
                table: "Plantings",
                newName: "CropId");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                schema: "Grow",
                table: "Plantings",
                newName: "BatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_UserID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_LocationID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_CropID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_BatchID",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_BatchId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Grow",
                table: "PlantingPatterns",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingPatterns_UserID",
                schema: "Grow",
                table: "PlantingPatterns",
                newName: "IX_PlantingPatterns_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Map",
                table: "Maps",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CollectionID",
                schema: "Map",
                table: "Maps",
                newName: "CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_UserID",
                schema: "Map",
                table: "Maps",
                newName: "IX_Maps_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Map",
                table: "MapObjects",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MapID",
                schema: "Map",
                table: "MapObjects",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_MapObjects_UserID",
                schema: "Map",
                table: "MapObjects",
                newName: "IX_MapObjects_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MapObjects_MapID",
                schema: "Map",
                table: "MapObjects",
                newName: "IX_MapObjects_MapId");

            migrationBuilder.RenameColumn(
                name: "StockItemsID",
                table: "LocationStockItem",
                newName: "StockItemsId");

            migrationBuilder.RenameColumn(
                name: "LocationsID",
                table: "LocationStockItem",
                newName: "LocationsId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationStockItem_StockItemsID",
                table: "LocationStockItem",
                newName: "IX_LocationStockItem_StockItemsId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Admin",
                table: "Locations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                schema: "Admin",
                table: "Locations",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "MapObjectID",
                schema: "Admin",
                table: "Locations",
                newName: "MapObjectId");

            migrationBuilder.RenameColumn(
                name: "IconID",
                schema: "Admin",
                table: "Locations",
                newName: "IconId");

            migrationBuilder.RenameColumn(
                name: "BusinessID",
                schema: "Admin",
                table: "Locations",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                schema: "Admin",
                table: "Locations",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_UserID",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ParentID",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_IconID",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_IconId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_BusinessID",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressID1",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_AddressId1");

            migrationBuilder.RenameColumn(
                name: "IconsID",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "IconsId");

            migrationBuilder.RenameColumn(
                name: "CollectionsID",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "CollectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_IconIconCollection_IconsID",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "IX_IconIconCollection_IconsId");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                schema: "Admin",
                table: "IconCollections",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Grow",
                table: "Crops",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SpeciesID",
                schema: "Grow",
                table: "Crops",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_UserID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_SpeciesID",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_PlantId");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                schema: "Inventory",
                table: "Categories",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentID",
                schema: "Inventory",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Admin",
                table: "Businesses",
                newName: "UserId");


            migrationBuilder.RenameIndex(
                name: "IX_Businesses_UserID",
                schema: "Admin",
                table: "Businesses",
                newName: "IX_Businesses_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Grow",
                table: "Batches",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SalesOrderID",
                schema: "Grow",
                table: "Batches",
                newName: "SalesOrderId");

            migrationBuilder.RenameColumn(
                name: "CropID",
                schema: "Grow",
                table: "Batches",
                newName: "CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_UserID",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CropID",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_CropId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Admin",
                table: "Address",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BusinessID",
                schema: "Admin",
                table: "Address",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                schema: "Admin",
                table: "Address",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserID",
                schema: "Admin",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_BusinessID",
                schema: "Admin",
                table: "Address",
                newName: "IX_Address_BusinessId");

            migrationBuilder.RenameColumn(
                name: "VarietyID",
                schema: "Grow",
                table: "Plants",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "StrainID",
                schema: "Grow",
                table: "Plants",
                newName: "Parent2Id");

            migrationBuilder.RenameColumn(
                name: "PropagationType",
                schema: "Grow",
                table: "Plants",
                newName: "TaxonType");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                schema: "Grow",
                table: "Plants",
                newName: "Parent1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_StrainID",
                schema: "Grow",
                table: "Plants",
                newName: "IX_Plants_Parent2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_ParentID",
                schema: "Grow",
                table: "Plants",
                newName: "IX_Plants_Parent1Id");

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Plants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CultivarName",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Plants",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Grow",
                table: "Plants",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genus",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantType",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Species",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Grow",
                table: "Plants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlantProfiles",
                schema: "Grow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TraitDefinitions",
                schema: "Grow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlwaysShow = table.Column<bool>(type: "bit", nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraitDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraitDefinitions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantTraits",
                schema: "Grow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefinitionId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantTraits_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantTraits_TraitDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalSchema: "Grow",
                        principalTable: "TraitDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantProfilePlantTrait",
                schema: "Grow",
                columns: table => new
                {
                    ProfilesId = table.Column<int>(type: "int", nullable: false),
                    TraitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantProfilePlantTrait", x => new { x.ProfilesId, x.TraitsId });
                    table.ForeignKey(
                        name: "FK_PlantProfilePlantTrait_PlantProfiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalSchema: "Grow",
                        principalTable: "PlantProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantProfilePlantTrait_PlantTraits_TraitsId",
                        column: x => x.TraitsId,
                        principalSchema: "Grow",
                        principalTable: "PlantTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_MapObjectId",
                schema: "Grow",
                table: "PlantingSections",
                column: "MapObjectId",
                unique: true,
                filter: "[MapObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapObjectId",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectId",
                unique: true,
                filter: "[MapObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ProfileId",
                schema: "Grow",
                table: "Plants",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                schema: "Grow",
                table: "Plants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantProfilePlantTrait_TraitsId",
                schema: "Grow",
                table: "PlantProfilePlantTrait",
                column: "TraitsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantProfiles_UserId",
                schema: "Grow",
                table: "PlantProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTraits_DefinitionId",
                schema: "Grow",
                table: "PlantTraits",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTraits_UserId",
                schema: "Grow",
                table: "PlantTraits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TraitDefinitions_UserId",
                schema: "Grow",
                table: "TraitDefinitions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserId",
                schema: "Admin",
                table: "Address",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Businesses_BusinessId",
                schema: "Admin",
                table: "Address",
                column: "BusinessId",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_AspNetUsers_UserId",
                schema: "Grow",
                table: "Batches",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Crops_CropId",
                schema: "Grow",
                table: "Batches",
                column: "CropId",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_UserId",
                schema: "Admin",
                table: "Businesses",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                schema: "Inventory",
                table: "Categories",
                column: "ParentId",
                principalSchema: "Inventory",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Circles_MapObjects_Id",
                schema: "Map",
                table: "Circles",
                column: "Id",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_StockItems_Id",
                schema: "Inventory",
                table: "Consumables",
                column: "Id",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_AspNetUsers_UserId",
                schema: "Grow",
                table: "Crops",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Plants_PlantId",
                schema: "Grow",
                table: "Crops",
                column: "PlantId",
                principalSchema: "Grow",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Durables_StockItems_Id",
                schema: "Inventory",
                table: "Durables",
                column: "Id",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IconCollections_IconCollections_ParentId",
                schema: "Admin",
                table: "IconCollections",
                column: "ParentId",
                principalSchema: "Admin",
                principalTable: "IconCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IconIconCollection_IconCollections_CollectionsId",
                schema: "Admin",
                table: "IconIconCollection",
                column: "CollectionsId",
                principalSchema: "Admin",
                principalTable: "IconCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IconIconCollection_Icons_IconsId",
                schema: "Admin",
                table: "IconIconCollection",
                column: "IconsId",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_MapObjects_Id",
                schema: "Map",
                table: "Lines",
                column: "Id",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressId",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressId1",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressId2",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                schema: "Admin",
                table: "Locations",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_BusinessId",
                schema: "Admin",
                table: "Locations",
                column: "BusinessId",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_BusinessId1",
                schema: "Admin",
                table: "Locations",
                column: "BusinessId",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Icons_IconId",
                schema: "Admin",
                table: "Locations",
                column: "IconId",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locations_ParentId",
                schema: "Admin",
                table: "Locations",
                column: "ParentId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MapObjects_MapObjectId",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectId",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationStockItem_Locations_LocationsId",
                table: "LocationStockItem",
                column: "LocationsId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationStockItem_StockItems_StockItemsId",
                table: "LocationStockItem",
                column: "StockItemsId",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapObjects_AspNetUsers_UserId",
                schema: "Map",
                table: "MapObjects",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapObjects_Maps_MapId",
                schema: "Map",
                table: "MapObjects",
                column: "MapId",
                principalSchema: "Map",
                principalTable: "Maps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_AspNetUsers_UserId",
                schema: "Map",
                table: "Maps",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingPatterns_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantingPatterns",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_AspNetUsers_UserId",
                schema: "Grow",
                table: "Plantings",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Batches_BatchId",
                schema: "Grow",
                table: "Plantings",
                column: "BatchId",
                principalSchema: "Grow",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Crops_CropId",
                schema: "Grow",
                table: "Plantings",
                column: "CropId",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_LocationId",
                schema: "Grow",
                table: "Plantings",
                column: "LocationId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantingSections",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_MapObjects_MapObjectId",
                schema: "Grow",
                table: "PlantingSections",
                column: "MapObjectId",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_PlantingPatterns_PatternId",
                schema: "Grow",
                table: "PlantingSections",
                column: "PatternId",
                principalSchema: "Grow",
                principalTable: "PlantingPatterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_PlantingSections_ParentId",
                schema: "Grow",
                table: "PlantingSections",
                column: "ParentId",
                principalSchema: "Grow",
                principalTable: "PlantingSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_Plantings_PlantingId",
                schema: "Grow",
                table: "PlantingSections",
                column: "PlantingId",
                principalSchema: "Grow",
                principalTable: "Plantings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_UserId",
                schema: "Grow",
                table: "Plants",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantProfiles_ProfileId",
                schema: "Grow",
                table: "Plants",
                column: "ProfileId",
                principalSchema: "Grow",
                principalTable: "PlantProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Plants_Parent1Id",
                schema: "Grow",
                table: "Plants",
                column: "Parent1Id",
                principalSchema: "Grow",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Plants_Parent2Id",
                schema: "Grow",
                table: "Plants",
                column: "Parent2Id",
                principalSchema: "Grow",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Icons_IconId",
                schema: "Map",
                table: "Points",
                column: "IconId",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_MapObjects_Id",
                schema: "Map",
                table: "Points",
                column: "Id",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polygons_MapObjects_Id",
                schema: "Map",
                table: "Polygons",
                column: "Id",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserId",
                schema: "Products",
                table: "ProductBatches",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatches_Products_ProductId",
                schema: "Products",
                table: "ProductBatches",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Locations_LocationId",
                schema: "Products",
                table: "ProductItems",
                column: "LocationId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Plantings_PlantingId",
                schema: "Products",
                table: "ProductItems",
                column: "PlantingId",
                principalSchema: "Grow",
                principalTable: "Plantings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_ProductBatches_BatchId",
                schema: "Products",
                table: "ProductItems",
                column: "BatchId",
                principalSchema: "Products",
                principalTable: "ProductBatches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                schema: "Products",
                table: "ProductItems",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderId",
                schema: "Products",
                table: "ProductItems",
                column: "SalesOrderId",
                principalSchema: "Inventory",
                principalTable: "SalesOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                schema: "Products",
                table: "Products",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderStockItem_PurchaseOrder_PurchaseOrdersId",
                table: "PurchaseOrderStockItem",
                column: "PurchaseOrdersId",
                principalSchema: "Products",
                principalTable: "PurchaseOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderStockItem_StockItems_ItemsId",
                table: "PurchaseOrderStockItem",
                column: "ItemsId",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_UserId",
                schema: "Inventory",
                table: "Resources",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Categories_CategoryId",
                schema: "Inventory",
                table: "Resources",
                column: "CategoryId",
                principalSchema: "Inventory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserId",
                schema: "Inventory",
                table: "SalesOrders",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_AspNetUsers_UserId",
                schema: "Inventory",
                table: "StockItems",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Resources_ResourceId",
                schema: "Inventory",
                table: "StockItems",
                column: "ResourceId",
                principalSchema: "Inventory",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_AspNetUsers_ManagerId",
                schema: "Inventory",
                table: "TransferApprovals",
                column: "ManagerId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferId",
                schema: "Inventory",
                table: "TransferApprovals",
                column: "TransferId",
                principalSchema: "Inventory",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_UserId",
                schema: "Inventory",
                table: "Transfers",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_DestinationId",
                schema: "Inventory",
                table: "Transfers",
                column: "DestinationId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_OriginId",
                schema: "Inventory",
                table: "Transfers",
                column: "OriginId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_StockItems_StockItemId",
                schema: "Inventory",
                table: "Transfers",
                column: "StockItemId",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Businesses_BusinessId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_AspNetUsers_UserId",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Crops_CropId",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_UserId",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Circles_MapObjects_Id",
                schema: "Map",
                table: "Circles");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_StockItems_Id",
                schema: "Inventory",
                table: "Consumables");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_AspNetUsers_UserId",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Plants_PlantId",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Durables_StockItems_Id",
                schema: "Inventory",
                table: "Durables");

            migrationBuilder.DropForeignKey(
                name: "FK_IconCollections_IconCollections_ParentId",
                schema: "Admin",
                table: "IconCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_IconIconCollection_IconCollections_CollectionsId",
                schema: "Admin",
                table: "IconIconCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_IconIconCollection_Icons_IconsId",
                schema: "Admin",
                table: "IconIconCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_Lines_MapObjects_Id",
                schema: "Map",
                table: "Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressId1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressId2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_BusinessId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_BusinessId1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Icons_IconId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locations_ParentId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MapObjects_MapObjectId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationStockItem_Locations_LocationsId",
                table: "LocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationStockItem_StockItems_StockItemsId",
                table: "LocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_AspNetUsers_UserId",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_MapObjects_Maps_MapId",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_AspNetUsers_UserId",
                schema: "Map",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingPatterns_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantingPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_AspNetUsers_UserId",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Batches_BatchId",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Crops_CropId",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Locations_LocationId",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_MapObjects_MapObjectId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_PlantingPatterns_PatternId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_PlantingSections_ParentId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingSections_Plantings_PlantingId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_UserId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantProfiles_ProfileId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Plants_Parent1Id",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Plants_Parent2Id",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Icons_IconId",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_MapObjects_Id",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Polygons_MapObjects_Id",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserId",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBatches_Products_ProductId",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Locations_LocationId",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Plantings_PlantingId",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_ProductBatches_BatchId",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderId",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderStockItem_PurchaseOrder_PurchaseOrdersId",
                table: "PurchaseOrderStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderStockItem_StockItems_ItemsId",
                table: "PurchaseOrderStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_UserId",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Categories_CategoryId",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserId",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_AspNetUsers_UserId",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Resources_ResourceId",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_AspNetUsers_ManagerId",
                schema: "Inventory",
                table: "TransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferId",
                schema: "Inventory",
                table: "TransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_UserId",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_DestinationId",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_OriginId",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_StockItems_StockItemId",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "PlantProfilePlantTrait",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "PlantProfiles",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "PlantTraits",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "TraitDefinitions",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_PlantingSections_MapObjectId",
                schema: "Grow",
                table: "PlantingSections");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapObjectId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Plants_ProfileId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_UserId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CommonName",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CultivarName",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CustomName",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Family",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Genus",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantType",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Species",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Grow",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "Plants",
                schema: "Grow",
                newName: "Plants",
                newSchema: "Inventory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Inventory",
                table: "Transfers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "StockItemId",
                schema: "Inventory",
                table: "Transfers",
                newName: "StockItemID");

            migrationBuilder.RenameColumn(
                name: "OriginId",
                schema: "Inventory",
                table: "Transfers",
                newName: "OriginID");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                schema: "Inventory",
                table: "Transfers",
                newName: "DestinationID");

            migrationBuilder.RenameColumn(
                name: "ApprovalId",
                schema: "Inventory",
                table: "Transfers",
                newName: "ApprovalID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Transfers",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_UserId",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_StockItemId",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_StockItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_OriginId",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_OriginID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationId",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_DestinationID");

            migrationBuilder.RenameColumn(
                name: "TransferId",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "TransferID");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "ManagerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferApprovals_TransferId",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "IX_TransferApprovals_TransferID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferApprovals_ManagerId",
                schema: "Inventory",
                table: "TransferApprovals",
                newName: "IX_TransferApprovals_ManagerID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Inventory",
                table: "StockItems",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                schema: "Inventory",
                table: "StockItems",
                newName: "ResourceID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "StockItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_UserId",
                schema: "Inventory",
                table: "StockItems",
                newName: "IX_StockItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_ResourceId",
                schema: "Inventory",
                table: "StockItems",
                newName: "IX_StockItems_ResourceID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrders_UserId",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "IX_SalesOrders_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Inventory",
                table: "Resources",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                schema: "Inventory",
                table: "Resources",
                newName: "SellerID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "Inventory",
                table: "Resources",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Resources",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_UserId",
                schema: "Inventory",
                table: "Resources",
                newName: "IX_Resources_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_CategoryId",
                schema: "Inventory",
                table: "Resources",
                newName: "IX_Resources_CategoryID");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrdersId",
                table: "PurchaseOrderStockItem",
                newName: "PurchaseOrdersID");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "PurchaseOrderStockItem",
                newName: "ItemsID");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderStockItem_PurchaseOrdersId",
                table: "PurchaseOrderStockItem",
                newName: "IX_PurchaseOrderStockItem_PurchaseOrdersID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "Products",
                table: "PurchaseOrder",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Products",
                table: "PurchaseOrder",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Products",
                table: "Products",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Products",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                schema: "Products",
                table: "Products",
                newName: "IX_Products_UserID");

            migrationBuilder.RenameColumn(
                name: "SalesOrderId",
                schema: "Products",
                table: "ProductItems",
                newName: "SalesOrderID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "Products",
                table: "ProductItems",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "PlantingId",
                schema: "Products",
                table: "ProductItems",
                newName: "PlantingID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "Products",
                table: "ProductItems",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                schema: "Products",
                table: "ProductItems",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Products",
                table: "ProductItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_SalesOrderId",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_SalesOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_ProductId",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_PlantingId",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_PlantingID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_LocationId",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_BatchId",
                schema: "Products",
                table: "ProductItems",
                newName: "IX_ProductItems_BatchID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Products",
                table: "ProductBatches",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "Products",
                table: "ProductBatches",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Products",
                table: "ProductBatches",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBatches_UserId",
                schema: "Products",
                table: "ProductBatches",
                newName: "IX_ProductBatches_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBatches_ProductId",
                schema: "Products",
                table: "ProductBatches",
                newName: "IX_ProductBatches_ProductID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "Map",
                table: "Polygons",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "Polygons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "Map",
                table: "Points",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "IconId",
                schema: "Map",
                table: "Points",
                newName: "IconID");

            migrationBuilder.RenameColumn(
                name: "IconCollectionId",
                schema: "Map",
                table: "Points",
                newName: "IconCollectionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "Points",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Points_IconId",
                schema: "Map",
                table: "Points",
                newName: "IX_Points_IconID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PlantingId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "PlantingID");

            migrationBuilder.RenameColumn(
                name: "PatternId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "PatternID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "MapObjectId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "MapObjectID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Grow",
                table: "PlantingSections",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_UserId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_PlantingId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_PlantingID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_PatternId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_PatternID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingSections_ParentId",
                schema: "Grow",
                table: "PlantingSections",
                newName: "IX_PlantingSections_ParentID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Grow",
                table: "Plantings",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "Grow",
                table: "Plantings",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "CropId",
                schema: "Grow",
                table: "Plantings",
                newName: "CropID");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                schema: "Grow",
                table: "Plantings",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Grow",
                table: "Plantings",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_UserId",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_LocationId",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_CropId",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Plantings_BatchId",
                schema: "Grow",
                table: "Plantings",
                newName: "IX_Plantings_BatchID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Grow",
                table: "PlantingPatterns",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Grow",
                table: "PlantingPatterns",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantingPatterns_UserId",
                schema: "Grow",
                table: "PlantingPatterns",
                newName: "IX_PlantingPatterns_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Map",
                table: "Maps",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                schema: "Map",
                table: "Maps",
                newName: "CollectionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "Maps",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_UserId",
                schema: "Map",
                table: "Maps",
                newName: "IX_Maps_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Map",
                table: "MapObjects",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "MapId",
                schema: "Map",
                table: "MapObjects",
                newName: "MapID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "MapObjects",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_MapObjects_UserId",
                schema: "Map",
                table: "MapObjects",
                newName: "IX_MapObjects_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_MapObjects_MapId",
                schema: "Map",
                table: "MapObjects",
                newName: "IX_MapObjects_MapID");

            migrationBuilder.RenameColumn(
                name: "StockItemsId",
                table: "LocationStockItem",
                newName: "StockItemsID");

            migrationBuilder.RenameColumn(
                name: "LocationsId",
                table: "LocationStockItem",
                newName: "LocationsID");

            migrationBuilder.RenameIndex(
                name: "IX_LocationStockItem_StockItemsId",
                table: "LocationStockItem",
                newName: "IX_LocationStockItem_StockItemsID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Admin",
                table: "Locations",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "Admin",
                table: "Locations",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "MapObjectId",
                schema: "Admin",
                table: "Locations",
                newName: "MapObjectID");

            migrationBuilder.RenameColumn(
                name: "IconId",
                schema: "Admin",
                table: "Locations",
                newName: "IconID");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                schema: "Admin",
                table: "Locations",
                newName: "BusinessID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                schema: "Admin",
                table: "Locations",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "Locations",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_UserId",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ParentId",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_IconId",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_IconID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_BusinessId",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_BusinessID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId2",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_AddressID2");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId1",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_AddressID1");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "Lines",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "Inputs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "Icons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IconsId",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "IconsID");

            migrationBuilder.RenameColumn(
                name: "CollectionsId",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "CollectionsID");

            migrationBuilder.RenameIndex(
                name: "IX_IconIconCollection_IconsId",
                schema: "Admin",
                table: "IconIconCollection",
                newName: "IX_IconIconCollection_IconsID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "Admin",
                table: "IconCollections",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "IconCollections",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_IconCollections_ParentId",
                schema: "Admin",
                table: "IconCollections",
                newName: "IX_IconCollections_ParentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Durables",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Grow",
                table: "Crops",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Grow",
                table: "Crops",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                schema: "Grow",
                table: "Crops",
                newName: "SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_UserId",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_PlantId",
                schema: "Grow",
                table: "Crops",
                newName: "IX_Crops_SpeciesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "ContainerTypes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Consumables",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Map",
                table: "Circles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "Inventory",
                table: "Categories",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Categories",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                schema: "Inventory",
                table: "Categories",
                newName: "IX_Categories_ParentID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Admin",
                table: "Businesses",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "Businesses",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_UserId",
                schema: "Admin",
                table: "Businesses",
                newName: "IX_Businesses_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Grow",
                table: "Batches",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SalesOrderId",
                schema: "Grow",
                table: "Batches",
                newName: "SalesOrderID");

            migrationBuilder.RenameColumn(
                name: "CropId",
                schema: "Grow",
                table: "Batches",
                newName: "CropID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Grow",
                table: "Batches",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_UserId",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CropId",
                schema: "Grow",
                table: "Batches",
                newName: "IX_Batches_CropID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Admin",
                table: "Address",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                schema: "Admin",
                table: "Address",
                newName: "BusinessID");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                schema: "Admin",
                table: "Address",
                newName: "BuildingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Admin",
                table: "Address",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                schema: "Admin",
                table: "Address",
                newName: "IX_Address_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_BusinessId",
                schema: "Admin",
                table: "Address",
                newName: "IX_Address_BusinessID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Inventory",
                table: "Plants",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TaxonType",
                schema: "Inventory",
                table: "Plants",
                newName: "PropagationType");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                schema: "Inventory",
                table: "Plants",
                newName: "VarietyID");

            migrationBuilder.RenameColumn(
                name: "Parent2Id",
                schema: "Inventory",
                table: "Plants",
                newName: "StrainID");

            migrationBuilder.RenameColumn(
                name: "Parent1Id",
                schema: "Inventory",
                table: "Plants",
                newName: "ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_Parent2Id",
                schema: "Inventory",
                table: "Plants",
                newName: "IX_Plants_StrainID");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_Parent1Id",
                schema: "Inventory",
                table: "Plants",
                newName: "IX_Plants_ParentID");

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrainID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VarietyID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "Inventory",
                table: "Plants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CropID",
                schema: "Inventory",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Inventory",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phase",
                schema: "Inventory",
                table: "Plants",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesID",
                schema: "Inventory",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrackingID",
                schema: "Inventory",
                table: "Plants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cultivars",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BreedingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Generation = table.Column<int>(type: "int", nullable: false),
                    Genotype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hybrid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patented = table.Column<bool>(type: "bit", nullable: false),
                    Phenotype = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cultivars_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                schema: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstInstallDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastMaintenanceCheck = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lights_StockItems_ID",
                        column: x => x.ID,
                        principalSchema: "Inventory",
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                schema: "Grow",
                columns: table => new
                {
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantingDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blooms = table.Column<bool>(type: "bit", nullable: false),
                    Fruits = table.Column<bool>(type: "bit", nullable: false),
                    Seeds = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spread = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardinessZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantingMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToMaturity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropagationTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterNeedsQty = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    WaterQtyUOM = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    WaterNeedsFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilDrainage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealAirTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealSoilTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealHumidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealLightHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealpH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropagationMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardenOff = table.Column<bool>(type: "bit", nullable: true),
                    HardenOffDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestSignifiers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropRotationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonPests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanionPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvoidPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attracts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Species_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Species_UoMs_WaterQtyUOM",
                        column: x => x.WaterQtyUOM,
                        principalSchema: "Admin",
                        principalTable: "UoMs",
                        principalColumn: "UnitName");
                });

            migrationBuilder.CreateTable(
                name: "Strains",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Generation = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OriginID = table.Column<int>(type: "int", nullable: true),
                    OriginType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StrainType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Strains_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantEvents",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ContainerTypeID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EventSubType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LightID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NewPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PruneType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasteQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    WasteQuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferID = table.Column<int>(type: "int", nullable: true),
                    NewContainerID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    QuantityApplied = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    QuantityUoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TreatmentType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantEvents_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Consumables_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Inventory",
                        principalTable: "Consumables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantEvents_ContainerTypes_ContainerTypeID",
                        column: x => x.ContainerTypeID,
                        principalSchema: "Admin",
                        principalTable: "ContainerTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PlantEvents_ContainerTypes_NewContainerID",
                        column: x => x.NewContainerID,
                        principalSchema: "Admin",
                        principalTable: "ContainerTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Lights_LightID",
                        column: x => x.LightID,
                        principalSchema: "Inventory",
                        principalTable: "Lights",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PlantEvents_Plants_PlantID",
                        column: x => x.PlantID,
                        principalSchema: "Inventory",
                        principalTable: "Plants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Transfers_TransferID",
                        column: x => x.TransferID,
                        principalSchema: "Inventory",
                        principalTable: "Transfers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Varieties",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phenotype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varieties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Varieties_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Varieties_Species_SpeciesID",
                        column: x => x.SpeciesID,
                        principalSchema: "Grow",
                        principalTable: "Species",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrainRelationships",
                columns: table => new
                {
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    ChildID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrainRelationships", x => new { x.ParentID, x.ChildID });
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ChildID",
                        column: x => x.ChildID,
                        principalSchema: "Grow",
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "Grow",
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_MapObjectID",
                schema: "Grow",
                table: "PlantingSections",
                column: "MapObjectID",
                unique: true,
                filter: "[MapObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressID",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                unique: true,
                filter: "[AddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID",
                unique: true,
                filter: "[MapObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CultivarID",
                schema: "Grow",
                table: "Crops",
                column: "CultivarID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_StrainID",
                schema: "Grow",
                table: "Crops",
                column: "StrainID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_VarietyID",
                schema: "Grow",
                table: "Crops",
                column: "VarietyID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CropID",
                schema: "Inventory",
                table: "Plants",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivars_UserID",
                schema: "Grow",
                table: "Cultivars",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_ContainerTypeID",
                schema: "Grow",
                table: "PlantEvents",
                column: "ContainerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_LightID",
                schema: "Grow",
                table: "PlantEvents",
                column: "LightID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_NewContainerID",
                schema: "Grow",
                table: "PlantEvents",
                column: "NewContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_PlantID",
                schema: "Grow",
                table: "PlantEvents",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_ProductID",
                schema: "Grow",
                table: "PlantEvents",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_TransferID",
                schema: "Grow",
                table: "PlantEvents",
                column: "TransferID",
                unique: true,
                filter: "[TransferID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_UserID",
                schema: "Grow",
                table: "PlantEvents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesName",
                schema: "Grow",
                table: "Species",
                column: "SpeciesName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_UserID",
                schema: "Grow",
                table: "Species",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_WaterQtyUOM",
                schema: "Grow",
                table: "Species",
                column: "WaterQtyUOM");

            migrationBuilder.CreateIndex(
                name: "IX_StrainRelationships_ChildID",
                table: "StrainRelationships",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Strains_Name",
                schema: "Grow",
                table: "Strains",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strains_UserID",
                schema: "Grow",
                table: "Strains",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_SpeciesID",
                schema: "Grow",
                table: "Varieties",
                column: "SpeciesID");

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_UserID",
                schema: "Grow",
                table: "Varieties",
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
                name: "FK_Address_Businesses_BusinessID",
                schema: "Admin",
                table: "Address",
                column: "BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_AspNetUsers_UserID",
                schema: "Grow",
                table: "Batches",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_Businesses_AspNetUsers_UserID",
                schema: "Admin",
                table: "Businesses",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentID",
                schema: "Inventory",
                table: "Categories",
                column: "ParentID",
                principalSchema: "Inventory",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Circles_MapObjects_ID",
                schema: "Map",
                table: "Circles",
                column: "ID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_StockItems_ID",
                schema: "Inventory",
                table: "Consumables",
                column: "ID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_AspNetUsers_UserID",
                schema: "Grow",
                table: "Crops",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Durables_StockItems_ID",
                schema: "Inventory",
                table: "Durables",
                column: "ID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IconCollections_IconCollections_ParentID",
                schema: "Admin",
                table: "IconCollections",
                column: "ParentID",
                principalSchema: "Admin",
                principalTable: "IconCollections",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IconIconCollection_IconCollections_CollectionsID",
                schema: "Admin",
                table: "IconIconCollection",
                column: "CollectionsID",
                principalSchema: "Admin",
                principalTable: "IconCollections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IconIconCollection_Icons_IconsID",
                schema: "Admin",
                table: "IconIconCollection",
                column: "IconsID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_MapObjects_ID",
                schema: "Map",
                table: "Lines",
                column: "ID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID1",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_UserID",
                schema: "Admin",
                table: "Locations",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_BusinessID",
                schema: "Admin",
                table: "Locations",
                column: "BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_BusinessID1",
                schema: "Admin",
                table: "Locations",
                column: "BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations",
                column: "IconID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locations_ParentID",
                schema: "Admin",
                table: "Locations",
                column: "ParentID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationStockItem_Locations_LocationsID",
                table: "LocationStockItem",
                column: "LocationsID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationStockItem_StockItems_StockItemsID",
                table: "LocationStockItem",
                column: "StockItemsID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Maps_AspNetUsers_UserID",
                schema: "Map",
                table: "Maps",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingPatterns_AspNetUsers_UserID",
                schema: "Grow",
                table: "PlantingPatterns",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_AspNetUsers_UserID",
                schema: "Grow",
                table: "Plantings",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings",
                column: "BatchID",
                principalSchema: "Grow",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_AspNetUsers_UserID",
                schema: "Grow",
                table: "PlantingSections",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_MapObjects_MapObjectID",
                schema: "Grow",
                table: "PlantingSections",
                column: "MapObjectID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_PlantingPatterns_PatternID",
                schema: "Grow",
                table: "PlantingSections",
                column: "PatternID",
                principalSchema: "Grow",
                principalTable: "PlantingPatterns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_PlantingSections_ParentID",
                schema: "Grow",
                table: "PlantingSections",
                column: "ParentID",
                principalSchema: "Grow",
                principalTable: "PlantingSections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingSections_Plantings_PlantingID",
                schema: "Grow",
                table: "PlantingSections",
                column: "PlantingID",
                principalSchema: "Grow",
                principalTable: "Plantings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Crops_CropID",
                schema: "Inventory",
                table: "Plants",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Plants_ParentID",
                schema: "Inventory",
                table: "Plants",
                column: "ParentID",
                principalSchema: "Inventory",
                principalTable: "Plants",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_StockItems_ID",
                schema: "Inventory",
                table: "Plants",
                column: "ID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Strains_StrainID",
                schema: "Inventory",
                table: "Plants",
                column: "StrainID",
                principalSchema: "Grow",
                principalTable: "Strains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Icons_IconID",
                schema: "Map",
                table: "Points",
                column: "IconID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_MapObjects_ID",
                schema: "Map",
                table: "Points",
                column: "ID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polygons_MapObjects_ID",
                schema: "Map",
                table: "Polygons",
                column: "ID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatches_AspNetUsers_UserID",
                schema: "Products",
                table: "ProductBatches",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBatches_Products_ProductID",
                schema: "Products",
                table: "ProductBatches",
                column: "ProductID",
                principalSchema: "Products",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Locations_LocationID",
                schema: "Products",
                table: "ProductItems",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Plantings_PlantingID",
                schema: "Products",
                table: "ProductItems",
                column: "PlantingID",
                principalSchema: "Grow",
                principalTable: "Plantings",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_ProductBatches_BatchID",
                schema: "Products",
                table: "ProductItems",
                column: "BatchID",
                principalSchema: "Products",
                principalTable: "ProductBatches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductID",
                schema: "Products",
                table: "ProductItems",
                column: "ProductID",
                principalSchema: "Products",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderID",
                schema: "Products",
                table: "ProductItems",
                column: "SalesOrderID",
                principalSchema: "Inventory",
                principalTable: "SalesOrders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                schema: "Products",
                table: "Products",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderStockItem_PurchaseOrder_PurchaseOrdersID",
                table: "PurchaseOrderStockItem",
                column: "PurchaseOrdersID",
                principalSchema: "Products",
                principalTable: "PurchaseOrder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderStockItem_StockItems_ItemsID",
                table: "PurchaseOrderStockItem",
                column: "ItemsID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Resources",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Categories_CategoryID",
                schema: "Inventory",
                table: "Resources",
                column: "CategoryID",
                principalSchema: "Inventory",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_AspNetUsers_UserID",
                schema: "Inventory",
                table: "SalesOrders",
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
                name: "FK_StockItems_Resources_ResourceID",
                schema: "Inventory",
                table: "StockItems",
                column: "ResourceID",
                principalSchema: "Inventory",
                principalTable: "Resources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_AspNetUsers_ManagerID",
                schema: "Inventory",
                table: "TransferApprovals",
                column: "ManagerID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferID",
                schema: "Inventory",
                table: "TransferApprovals",
                column: "TransferID",
                principalSchema: "Inventory",
                principalTable: "Transfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_DestinationID",
                schema: "Inventory",
                table: "Transfers",
                column: "DestinationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_OriginID",
                schema: "Inventory",
                table: "Transfers",
                column: "OriginID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_StockItems_StockItemID",
                schema: "Inventory",
                table: "Transfers",
                column: "StockItemID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
