CREATE PROCEDURE [dbo].[spToolComponents_Delete]
	@ToolId VARCHAR(20),
	@Position INT
AS
BEGIN
	SET NOCOUNT ON
	DELETE ToolComponents
	WHERE 
	ToolId = @ToolId AND
	Position = @Position
END