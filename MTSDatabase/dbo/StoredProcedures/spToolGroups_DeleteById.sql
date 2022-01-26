CREATE PROCEDURE [dbo].[spToolGroups_DeleteById]
	@Id VARCHAR(20),
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolGroups
	WHERE Id = @Id AND ToolClassId = @ToolClassId
END
