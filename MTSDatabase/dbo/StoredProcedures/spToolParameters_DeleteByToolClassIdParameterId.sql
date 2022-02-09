CREATE PROCEDURE [dbo].[spToolParameters_DeleteByToolClassIdParameterId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
	DELETE
	FROM ToolParameters
	WHERE
	ToolId IN
	(SELECT ToolId FROM Tools WHERE ToolClassId = @ToolClassId)
	AND ParameterId = @ParameterId