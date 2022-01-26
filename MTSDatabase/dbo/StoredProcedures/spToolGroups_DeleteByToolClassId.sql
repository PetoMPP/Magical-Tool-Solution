CREATE PROCEDURE [dbo].[spToolGroups_DeleteByToolClassId]
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolGroups
	WHERE ToolClassId = @ToolClassId
END
