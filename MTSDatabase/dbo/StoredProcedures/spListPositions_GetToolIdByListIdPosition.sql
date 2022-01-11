CREATE PROCEDURE [dbo].[spListPositions_GetToolIdByListIdPosition]
	@ListId VARCHAR(20),
	@Position INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT ToolId
	FROM ListPositions
	WHERE ListId = @ListId AND Position = @Position
END	