-- =============================================
-- Author:		Libby
-- Create date: 2/26/2025
-- Last Update: 3/19/2025 - Libby
-- Description:	Return inventory item details
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetResourcesTableData]

AS
BEGIN

SELECT
	CONCAT(cat0.Name, '-', CAST(cat0.Id as nvarchar), '-', cat0.HexColor) AS Cat0,
	CONCAT(Cat1Name, '-', CAST(Cat1Id as nvarchar), '-', Cat1Hex) AS Cat1,
	ItemId,
	ItemName,
	ItemDesc,
	Brand,
	SKU,
	UoM,
	StockType
FROM (
	SELECT 
		cat1.Id AS Cat1Id,
		ParentId,
		cat1.Name AS Cat1Name,		
		HexColor AS Cat1Hex,
		item.Id AS ItemId,
		item.Name AS ItemName,
		item.Description AS ItemDesc,
		Manufacturer AS Brand,
		SKU,
		DefaultUOM AS UoM,
		StockType,
		Tags
	FROM Inventory.Resources item
	INNER JOIN Inventory.Categories cat1 ON item.CategoryId = cat1.Id
	WHERE ParentId IS NOT NULL
)ch
LEFT JOIN Inventory.Categories cat0 ON cat0.Id = ch.ParentId
WHERE cat0.ParentId IS NULL

END
