CREATE PROCEDURE [dbo].[spToolClassParameters_GetByToolClassId]
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, ToolClassId, Position, Name, Description, DataValueType
	FROM ToolClassParameters
	WHERE ToolClassId = @ToolClassId
END