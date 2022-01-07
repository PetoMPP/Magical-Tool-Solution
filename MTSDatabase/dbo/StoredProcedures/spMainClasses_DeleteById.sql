CREATE PROCEDURE [dbo].[spMainClasses_DeleteById]
	@Id VARCHAR(20)
AS
BEGIN
	DELETE MainClasses
	WHERE Id = @Id
END
