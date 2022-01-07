CREATE PROCEDURE [dbo].[spToolSuitability_Delete]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE ToolSuitability
	WHERE ToolId = @ToolId
END