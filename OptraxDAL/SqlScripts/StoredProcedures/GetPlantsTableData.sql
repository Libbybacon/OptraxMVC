-- =============================================
-- Author:		Libby
-- Create date: 3/5/2025
-- Description:	
-- =============================================
CREATE OR ALTER PROCEDURE GetPlantsTableData

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT 
	plant.ID AS PlantID,
	CropID,
	plant.StrainID,
	TrackingID,
	strain.[Name] AS Strain,
	IsMother,
	StartType,
	StartPhase,
	crop.CurrentPhase,
	loc.[Name] AS LocationName,
	LocationType
FROM [Optrax].[dbo].[Plants] plant
INNER JOIN Strains strain ON plant.StrainID = strain.ID
LEFT JOIN Crops crop ON plant.CropID = crop.ID
LEFT JOIN InventoryLocation loc ON crop.LocationID = loc.ID

END
GO
