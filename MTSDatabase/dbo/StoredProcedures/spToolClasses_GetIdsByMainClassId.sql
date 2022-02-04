CREATE PROCEDURE [dbo].[spToolClasses_GetIdsByMainClassId]
	@MainClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id
	FROM ToolClasses
	WHERE ISNULL(MainClassId, '') = @MainClassId
END