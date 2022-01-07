CREATE PROCEDURE [dbo].[spToolSuitability_GetByToolId]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT ToolId, PSuitability, MSuitability, KSuitability, 
	NSuitability, SSuitability, HSuitability
	FROM ToolSuitability
	WHERE ToolId = @ToolId
END