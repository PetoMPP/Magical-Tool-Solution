CREATE PROCEDURE [dbo].[spMachineInterfaces_ValidateId]
	@Id varchar(20),
	@result int output
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MachineInterfaces 
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
