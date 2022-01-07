CREATE PROCEDURE [dbo].[spGetToolParameters_ByCompIdToolClassId]
	@ToolId VARCHAR(20),
	@ToolClassId VARCHAR(20)
AS
	BEGIN
	SET NOCOUNT ON
	SELECT a.Position, a.Id AS ParameterId, a.Name, a.Description, a.DataValueType, 
	b.NumericValue, b.TextValue
	FROM ToolClassParameters a
	INNER JOIN ToolParameters b ON a.Id = b.ParameterId
	WHERE a.ToolClassId = @ToolClassId AND b.ToolId = @ToolId
END