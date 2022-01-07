CREATE PROCEDURE [dbo].[spToolClasses_Insert]
	@Id VARCHAR(20),
	@Name NVARCHAR(120),
	@MainClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolClasses
	(Id, Name, MainClassId)
	VALUES 
	(@Id, @Name, @MainClassId)
END