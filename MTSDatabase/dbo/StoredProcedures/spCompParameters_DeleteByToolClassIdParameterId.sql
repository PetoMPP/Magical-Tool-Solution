CREATE PROCEDURE [dbo].[spCompParameters_DeleteByToolClassIdParameterId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
	DELETE
	FROM CompParameters
	WHERE
	CompId IN
	(SELECT CompId FROM Comps WHERE ToolClassId = @ToolClassId)
	AND ParameterId = @ParameterId