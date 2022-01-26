CREATE PROCEDURE [dbo].[spMachineGroups_ValidateId]
	@Id varchar(20)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MachineGroups
		WHERE Id = @Id)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
