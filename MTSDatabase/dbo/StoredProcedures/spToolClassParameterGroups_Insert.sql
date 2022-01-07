CREATE PROCEDURE [dbo].[spToolClassParameterGroups_Insert]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@ToolGroupId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolClassParameterGroups
	(ToolClassId, ParameterId, ToolGroupId)
	VALUES 
	(@ToolClassId, @ParameterId, @ToolGroupId)
END