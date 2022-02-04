CREATE PROCEDURE [dbo].[spListPositions_Update]
	@ListId VARCHAR(20),
	@Position INT,
	@CompId VARCHAR(20) = NULL,
	@ToolId VARCHAR(20) = NULL, 
	@Quantity INT
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ListPositions
	SET
	CompId = @CompId,
	ToolId = @ToolId,
	Quantity = @Quantity
	WHERE
	ListId = @ListId AND
	Position = @Position
END