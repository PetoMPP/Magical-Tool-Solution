CREATE PROCEDURE [dbo].[spListPositions_DeleteByListId]
	@ListId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ListPositions
	WHERE ListId = @ListId
END
