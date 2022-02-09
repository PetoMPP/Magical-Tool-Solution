CREATE PROCEDURE [dbo].[spMachineInterfaces_ValidateName]
	@Name nvarchar(120)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MachineInterfaces 
		WHERE Name = @Name)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
