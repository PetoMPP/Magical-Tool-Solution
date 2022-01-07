CREATE PROCEDURE [dbo].[spToolSuitability_DeleteByToolId]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolSuitability
	WHERE ToolId = @ToolId
END
