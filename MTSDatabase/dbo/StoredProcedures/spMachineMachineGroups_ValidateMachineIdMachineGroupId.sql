CREATE PROCEDURE [dbo].[spMachineMachineGroups_ValidateMachineIdMachineGroupId]
	@MachineId varchar(20),
	@MachineGroupId varchar(20)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MachineMachineGroups
		WHERE MachineId = @MachineId AND 
		MachineGroupId = @MachineGroupId)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
