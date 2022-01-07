CREATE PROCEDURE [dbo].[spMachineMachineGroups_ValidateMachineIdMachineGroupId]
	@MachineId varchar(20),
	@MachineGroupId varchar(20),
	@result int output
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (SELECT * FROM MachineMachineGroups
		WHERE MachineId = @MachineId AND 
		MachineGroupId = @MachineGroupId)
		BEGIN
			SET @result = 1
		END
	ELSE
		BEGIN
			SET @result = 0
		END
RETURN @result
END
