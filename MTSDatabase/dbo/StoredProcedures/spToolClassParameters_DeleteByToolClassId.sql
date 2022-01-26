CREATE PROCEDURE [dbo].[spToolClassParameters_DeleteByToolClassId]
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolClassParameters
	WHERE ToolClassId = @ToolClassId
END
