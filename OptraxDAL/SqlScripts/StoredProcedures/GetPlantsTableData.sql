
-- =============================================
-- Author:		Libby
-- Create date: 3/5/2025
-- Description:	
-- =============================================
ALTER   PROCEDURE [dbo].[GetPlantsTableData]

AS
BEGIN
	SET NOCOUNT ON;

SELECT 
	plant.ID AS PlantID,
	crop.BatchID AS CropID,
	plant.StrainID,
	TrackingID,
	CONCAT(strain.[Name], '-', CAST(strain.ID AS nvarchar)) AS Strain,
	IsMother,
	MotherName,
	Phase,
	OriginType,
	crop.CurrentPhase,
	loc.[Name] AS LocationName,
	LocationType,
	1 AS Quantity
FROM [Optrax].[dbo].[Plants] plant
INNER JOIN Strains strain ON plant.StrainID = strain.ID
LEFT JOIN Crops crop ON plant.CropID = crop.ID
LEFT JOIN InventoryLocations loc ON crop.LocationID = loc.ID

END
