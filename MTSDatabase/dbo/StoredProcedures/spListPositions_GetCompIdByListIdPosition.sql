CREATE PROCEDURE [dbo].[spListPositions_GetCompIdByListIdPosition]
	@ListId VARCHAR(20),
	@Position INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT CompId
	FROM ListPositions
	WHERE ListId = @ListId AND Position = @Position
END	