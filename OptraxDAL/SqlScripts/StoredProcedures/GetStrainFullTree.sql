-- =============================================
-- Author:  Libby
-- Create Date: 2/22/2025
-- Description: Get full family tree for particular strain
-- =============================================
CREATE PROCEDURE GetStrainFullTree
(
	@strainID int
)
AS
BEGIN

WITH Ancestors AS (
    SELECT ParentID, ChildID, 0 AS Generation
    FROM StrainRelationships
    WHERE ChildID = @strainId

    UNION ALL

    SELECT sr.ParentID, sr.ChildID, a.Generation + 1
    FROM StrainRelationships sr
    INNER JOIN Ancestors a ON sr.ChildID = a.ParentID
),
Children AS (
    SELECT ChildID, ParentID, 0 AS Generation
    FROM StrainRelationships
    WHERE ParentID = @strainId

    UNION ALL

    SELECT sr.ChildID, sr.ParentID, d.Generation + 1
    FROM StrainRelationships sr
    INNER JOIN Children d ON sr.ParentID = d.ChildID
)

SELECT  * 
FROM Ancestors

UNION ALL

SELECT * 
FROM Children

END
GO
