CREATE PROCEDURE [dbo].[spToolClassParameterGroups_DeleteByToolClassIdParameterIdToolGroupId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@ToolGroupId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE ToolClassParameterGroups
	WHERE 
	ToolClassId = @ToolClassId AND
	ParameterId = @ParameterId AND
	ToolGroupId = @ToolGroupId
END