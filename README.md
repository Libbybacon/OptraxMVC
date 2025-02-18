![logo-lt](https://github.com/user-attachments/assets/04da5b57-4199-4a50-ba70-7b44f896b77e)   
<sup>***Seed to Sale Operations Tracking for Indoor Growers***</sup>
# Getting Started  
  
**Required Packages**     
Microsoft.AspNetCore.Identity.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore.SqlServer(8.0.13)  
Microsoft.EntityFrameworkCore.Tools(8.0.13)  

**_**Update connection string in appsettings.json_**  

## Code First Migrations  
dotnet ef migrations add <migration name> --project OptraxDAL --startup-project OptraxMVC  
*dotnet ef migrations remove --project OptraxDAL --startup-project OptraxMVC*  
dotnet ef database update --project OptraxDAL --startup-project OptraxMVC  

## Populate Database   
```SQL
INSERT INTO [InventoryCategories]   
VALUES  
(NULL, 'Plant', NULL, 1),            --1
(NULL, 'Plant Care', NULL, 1),       --2
(NULL, 'Grow Equipment', NULL, 1),   --3
(NULL, 'Office Supplies', NULL, 1),  --4 
(1, 'Seed', NULL, 1),                --5
(1, 'Start', NULL, 1),               --6
(1, 'Mature', NULL, 1),              --7 
(2, 'Soil', NULL, 1),                --8
(2, 'Nutrients', NULL, 1),           --9
(2, 'Pest Control', NULL, 1),        --10
(3, 'Light', NULL, 1),               --11
(3, 'Container', NULL, 1),           --12
(3, 'Pruning', NULL, 1),             --13
(3, 'Hose', NULL, 1),                --14
(4, 'Print Supplies', NULL, 1),      --15
(4, 'Furniture', NULL, 1),           --16
(4, 'Shipping Supplies', NULL, 1),   --17
(17, 'Boxes', NULL, 1),              --18
(10, 'Diatomaceous Earth', NULL, 1), --19
(12, "Grow Container", NULL, 1),     --20
(12, "Storage Container", NULL, 1),  --21 

INSERT INTO InventoryItems  
VALUES  
(1, 'Plant', '', '', '', '', 'Per', NULL, NULL, NULL, 1, 1),  
(9, 'ConsumableItem', 'Tiger Bloom', "Ultra potent, fast acting, high phosphorus fertilizer that also contains a good supply of nitrogen for growth & vigor."', 'FoxFarm', '00752289793226', 'fl oz', NULL, NULL, NULL, 0, 1)
```
