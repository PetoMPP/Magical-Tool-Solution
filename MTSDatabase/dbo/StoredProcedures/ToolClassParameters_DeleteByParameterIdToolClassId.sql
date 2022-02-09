CREATE PROCEDURE [dbo].[ToolClassParameters_DeleteByParameterIdToolClassId]
	@ToolClassId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
	DELETE
	FROM ToolClassParameters
	WHERE ToolClassId = @ToolClassId AND Id = @ParameterId