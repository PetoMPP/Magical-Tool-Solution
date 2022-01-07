CREATE PROCEDURE [dbo].[spListPositions_GetByListId]
	@ListId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Position, Quantity
	FROM ListPositions
	WHERE ListId = @ListId
END	