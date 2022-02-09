CREATE PROCEDURE [dbo].[spToolParameters_DeleteByToolClassIdParameterIdToolGroupId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@ToolGroupId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE
	FROM ToolParameters 
	WHERE 
		ToolId IN (SELECT tp.ToolId FROM ToolParameters AS tp
		JOIN Comps As td ON tp.ToolId = td.Id
		WHERE tp.ParameterId = @ParameterId AND td.ToolClassId = @ToolClassId AND td.ToolGroupId = @ToolGroupId)
		AND
		ParameterId IN (SELECT tp.ParameterId FROM ToolParameters AS tp
		JOIN Comps As td ON tp.ToolId = td.Id
		WHERE tp.ParameterId = @ParameterId AND td.ToolClassId = @ToolClassId AND td.ToolGroupId = @ToolGroupId)
END