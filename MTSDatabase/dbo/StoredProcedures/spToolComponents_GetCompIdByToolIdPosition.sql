CREATE PROCEDURE [dbo].[spToolComponents_GetCompIdByToolIdPosition]
	@ToolId VARCHAR(20),
	@Position INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT CompId
	FROM ToolComponents
	WHERE ToolId = @ToolId AND Position = @Position
END	