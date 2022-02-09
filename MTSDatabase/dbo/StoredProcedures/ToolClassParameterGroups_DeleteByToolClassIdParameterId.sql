CREATE PROCEDURE [dbo].[ToolClassParameterGroups_DeleteByToolClassIdParameterId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
	DELETE
	FROM ToolClassParameterGroups
	WHERE ToolClassId = @ToolClassId AND ParameterId = @ParameterId
