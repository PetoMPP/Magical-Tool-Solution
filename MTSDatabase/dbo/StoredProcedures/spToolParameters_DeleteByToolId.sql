CREATE PROCEDURE [dbo].[spToolParameters_DeleteByToolId]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolParameters
	WHERE ToolId = @ToolId
END
