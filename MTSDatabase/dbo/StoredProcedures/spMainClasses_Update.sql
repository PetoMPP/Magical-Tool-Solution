CREATE PROCEDURE [dbo].[spMainClasses_Update]
	@Id VARCHAR(20),
	@Name NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE MainClasses
	SET Name = @Name
	WHERE Id = @Id
END