-- =============================================
-- Author:  Libby
-- Create Date: 2/22/2025
-- Description: Get full family tree for particular strain
-- =============================================
CREATE OR ALTER PROCEDURE GetStrainFullTree
(
	@strainId int
)
AS
BEGIN

WITH Ancestors AS (
    SELECT ParentId, ChildId, 0 AS Generation
    FROM StrainRelationships
    WHERE ChildId = @strainId

    UNION ALL

    SELECT sr.ParentId, sr.ChildId, a.Generation + 1
    FROM StrainRelationships sr
    INNER JOIN Ancestors a ON sr.ChildId = a.ParentId
),
Children AS (
    SELECT ChildId, ParentId, 0 AS Generation
    FROM StrainRelationships
    WHERE ParentId = @strainId

    UNION ALL

    SELECT sr.ChildId, sr.ParentId, d.Generation + 1
    FROM StrainRelationships sr
    INNER JOIN Children d ON sr.ParentId = d.ChildId
)

SELECT  * 
FROM Ancestors

UNION ALL

SELECT * 
FROM Children

END
GO
