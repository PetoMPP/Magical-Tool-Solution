CREATE PROCEDURE [dbo].[spToolClasses_UpdateMainClassIdById]
	@MainClassId VARCHAR(20),
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolClasses
	SET MainClassId = @MainClassId
	WHERE Id = @Id
END