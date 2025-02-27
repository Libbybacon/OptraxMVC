﻿-- =============================================
-- Author:		Libby
-- Create date: 2/26/2025
-- Description:	Return inventory item details
-- =============================================

CREATE OR ALTER PROCEDURE GetItemsTableData

AS
BEGIN

SELECT
	CONCAT(cat0.Name, '-', CAST(cat0.ID as nvarchar), '-', cat0.HexColor) AS Cat0,
	CONCAT(Cat1Name, '-', CAST(Cat1ID as nvarchar), '-', Cat1Hex) AS Cat1,
	ItemName,
	ItemDesc,
	Brand,
	SKU,
	UoM,
	StockType
FROM (
	SELECT 
		cat1.ID AS Cat1ID,
		ParentID,
		cat1.Name AS Cat1Name,		
		HexColor AS Cat1Hex,
		item.Name AS ItemName,
		item.Description AS ItemDesc,
		Manufacturer AS Brand,
		SKU,
		DefaultUOM AS UoM,
		StockType,
		Tags
	FROM InventoryItems item
	INNER JOIN InventoryCategories cat1 ON item.CategoryID = cat1.ID
	WHERE ParentID IS NOT NULL
)ch
LEFT JOIN InventoryCategories cat0 ON cat0.ID = ch.ParentID
WHERE cat0.ParentID IS NULL
ORDER BY Cat0, Cat1

END
GO
