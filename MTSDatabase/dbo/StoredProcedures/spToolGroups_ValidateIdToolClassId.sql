CREATE PROCEDURE [dbo].[spToolGroups_ValidateIdToolClassId]
	@ToolClassId varchar(20),
	@Id varchar(20),
	@result int output
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM ToolGroups 
		WHERE ToolClassId = @ToolClassId AND Id = @Id)
		BEGIN
			SET @result = 1
		END
	ELSE
		BEGIN
			SET @result = 0
		END
RETURN @result
END
