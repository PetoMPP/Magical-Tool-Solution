CREATE PROCEDURE [dbo].[spToolGroups_ValidateIdToolClassId]
	@ToolClassId varchar(20),
	@Id varchar(20)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM ToolGroups 
		WHERE ToolClassId = @ToolClassId AND Id = @Id)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
