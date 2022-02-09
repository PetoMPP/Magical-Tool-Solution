CREATE PROCEDURE [dbo].[spToolClasses_DeleteMainClassByMainClassId]
	@MainClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolClasses
	SET MainClassId = NULL
	WHERE ISNULL(MainClassId, 'UNDEFINED') = @MainClassId
END