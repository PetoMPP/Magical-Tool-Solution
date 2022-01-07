CREATE PROCEDURE [dbo].[spListPositions_Insert]
	@ListId VARCHAR(20),
	@Position INT,
	@CompId VARCHAR(20),
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	IF (@CompId != NULL)
		BEGIN
		INSERT INTO ListPositions
		(ListId, Position, CompId)
		VALUES 
		(@ListId, @Position, @CompId)
		END
	ELSE
		BEGIN
		INSERT INTO ListPositions
		(ListId, Position, ToolId)
		VALUES 
		(@ListId, @Position, @ToolId)
		END
END