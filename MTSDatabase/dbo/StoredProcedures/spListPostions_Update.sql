CREATE PROCEDURE [dbo].[spListPostions_Update]
	@ListId VARCHAR(20),
	@Position INT,
	@CompId VARCHAR(20),
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ListPositions
	SET
	CompId = @CompId,
	ToolId = @ToolId
	WHERE
	ListId = @ListId AND
	Position = @Position
END