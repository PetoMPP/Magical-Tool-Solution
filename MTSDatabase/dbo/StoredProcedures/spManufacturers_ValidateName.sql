CREATE PROCEDURE [dbo].[spManufacturers_ValidateName]
	@Name nvarchar(120),
	@result int output
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MainClasses 
		WHERE Name = @Name)
		BEGIN
			SET @result = 1
		END
	ELSE
		BEGIN
			SET @result = 0
		END
RETURN @result
END
