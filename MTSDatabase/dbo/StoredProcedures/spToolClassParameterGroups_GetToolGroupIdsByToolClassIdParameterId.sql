CREATE PROCEDURE [dbo].[spToolClassParameterGroups_GetToolGroupIdsByToolClassIdParameterId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT ToolGroupId
	FROM ToolClassParameterGroups
	WHERE ToolClassId = @ToolClassId AND ParameterId = @ParameterId
END