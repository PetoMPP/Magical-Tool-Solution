CREATE PROCEDURE [dbo].[spToolClasses_Update]
	@Id VARCHAR(20),
	@Name NVARCHAR(120),
	@MainClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolClasses
	SET 
	Name = @Name,
	MainClassId = @MainClassId
	WHERE Id = @Id
END