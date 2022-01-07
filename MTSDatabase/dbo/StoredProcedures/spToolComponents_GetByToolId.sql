CREATE PROCEDURE [dbo].[spToolComponents_GetByToolId]
	@ToolId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT IsKey, Position, Quantity
	FROM ToolComponents
	WHERE ToolId = @ToolId
END