CREATE PROCEDURE [dbo].[spToolClasses_GetById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name, MainClassId
	FROM ToolClasses
	WHERE Id = @Id
END