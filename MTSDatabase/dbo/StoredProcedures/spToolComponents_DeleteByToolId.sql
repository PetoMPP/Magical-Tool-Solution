CREATE PROCEDURE [dbo].[spToolComponents_DeleteByToolId]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolComponents
	WHERE ToolId = @ToolId
END
