CREATE PROCEDURE [dbo].[spMaterials_ValidateId]
	@Id nvarchar(120)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM Materials 
		WHERE Id = @Id)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
