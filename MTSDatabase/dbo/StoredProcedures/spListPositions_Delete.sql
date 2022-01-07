CREATE PROCEDURE [dbo].[spListPositions_Delete]
	@ListId VARCHAR(20),
	@Position INT
AS
BEGIN
	SET NOCOUNT ON
	DELETE ListPositions
	WHERE
	ListId = @ListId AND
	Position = @Position
END