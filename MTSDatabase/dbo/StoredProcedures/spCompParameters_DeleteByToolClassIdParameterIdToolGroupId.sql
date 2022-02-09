CREATE PROCEDURE [dbo].[spCompParameters_DeleteByToolClassIdParameterIdToolGroupId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@ToolGroupId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE
	FROM CompParameters 
	WHERE 
		CompId IN (SELECT cp.CompId FROM CompParameters AS cp
		JOIN Comps As cd ON cp.CompId = cd.Id
		WHERE cp.ParameterId = @ParameterId AND cd.ToolClassId = @ToolClassId AND cd.ToolGroupId = @ToolGroupId)
		AND
		ParameterId IN (SELECT cp.ParameterId FROM CompParameters AS cp
		JOIN Comps As cd ON cp.CompId = cd.Id
		WHERE cp.ParameterId = @ParameterId AND cd.ToolClassId = @ToolClassId AND cd.ToolGroupId = @ToolGroupId)
END