CREATE PROCEDURE [dbo].[spToolClassParameters_GetNextPositionByToolClassId]
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS 
		(SELECT Position
		FROM
		ToolClassParameters
		WHERE ToolClassId = @ToolClassId)
		BEGIN
			(SELECT
			MAX(Position) + 1
			FROM
			ToolClassParameters
			WHERE ToolClassId = @ToolClassId)
		END
	ELSE
	BEGIN
		SELECT 1
	END
END