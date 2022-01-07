CREATE PROCEDURE [dbo].[spTools_ValidateId]
	@Id nvarchar(120),
	@result int output
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM Tools 
		WHERE Id = @Id)
		BEGIN
			SET @result = 1
		END
	ELSE
		BEGIN
			SET @result = 0
		END
RETURN @result
END
