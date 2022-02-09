CREATE PROCEDURE [dbo].[spToolParameters_DeleteByToolIdParameterId]
	@ToolId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolParameters
	WHERE ToolId = @ToolId AND ParameterId = @ParameterId
END
