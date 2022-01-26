CREATE PROCEDURE [dbo].[spToolClasses_ValidateId]
	@Id nvarchar(120)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM ToolClasses 
		WHERE Id = @Id)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
