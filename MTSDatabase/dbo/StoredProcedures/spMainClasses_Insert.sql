CREATE PROCEDURE [dbo].[spMainClasses_Insert]
	@Id VARCHAR(20),
	@Name NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO MainClasses
	(Id, Name)
	VALUES 
	(@Id, @Name)
END