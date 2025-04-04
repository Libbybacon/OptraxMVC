
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
	plant.Id AS PlantId,
	crop.BatchId AS CropId,
	plant.StrainId,
	TrackingId,
	CONCAT(strain.[Name], '-', CAST(strain.Id AS nvarchar)) AS Strain,
	IsMother,
	MotherName,
	Phase,
	plant.OriginType,
	crop.CurrentPhase,
	loc.[Name] AS LocationName,
	LocationType,
	1 AS Quantity
FROM [Optrax].[dbo].[Plants] plant
INNER JOIN Strains strain ON plant.StrainId = strain.Id
LEFT JOIN Crops crop ON plant.CropId = crop.Id
LEFT JOIN InventoryLocations loc ON crop.LocationId = loc.Id

END
