CREATE PROCEDURE [dbo].[spGetParametersByToolClassIdToolGroupId]
	@ToolClassId VARCHAR(20),
	@ToolGroupId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT a.Position, a.Id, a.Name, a.Description, a.DataValueType
	FROM ToolClassParameters as a
	JOIN ToolClassParameterGroups as b ON a.ToolClassId = b.ToolClassId AND a.Id = b.ParameterId
	WHERE a.ToolClassId = @ToolClassId AND b.ToolGroupId = @ToolGroupId
	ORDER BY a.Position
END