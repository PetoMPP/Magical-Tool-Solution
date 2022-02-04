CREATE PROCEDURE [dbo].[spToolGroups_GetNameById]
	@Id VARCHAR(20),
	@ToolClassID VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Name
	FROM ToolGroups
	WHERE Id = @Id AND ToolClassId = @ToolClassID
END