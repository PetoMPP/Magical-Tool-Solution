CREATE PROCEDURE [dbo].[spListPositions_Insert]
	@ListId VARCHAR(20),
	@Position INT,
	@CompId VARCHAR(20) = NULL,
	@ToolId VARCHAR(20) = NULL,
	@Quantity INT
AS
BEGIN
	SET NOCOUNT ON
	IF (@CompId != NULL)
		BEGIN
		INSERT INTO ListPositions
		(ListId, Position, CompId, Quantity)
		VALUES 
		(@ListId, @Position, @CompId, @Quantity)
		END
	ELSE
		BEGIN
		INSERT INTO ListPositions
		(ListId, Position, ToolId, Quantity)
		VALUES 
		(@ListId, @Position, @ToolId, @Quantity)
		END
END