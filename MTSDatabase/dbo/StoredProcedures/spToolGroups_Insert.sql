CREATE PROCEDURE [dbo].[spToolGroups_Insert]
	@Id VARCHAR(20),
	@Name NVARCHAR(120),
	@ToolClassId VARCHAR(20),
	@SuitabilityEnabled BIT,
	@MachineInterfaceEnabled BIT,
	@InsertsEnabled BIT,
	@HoldingOtherComponentsEnabled BIT,
	@EnabledInComps BIT,
	@EnabledInTools BIT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolGroups
	VALUES 
	(@Id, @Name, @ToolClassId, @SuitabilityEnabled, @MachineInterfaceEnabled,
	@InsertsEnabled, @HoldingOtherComponentsEnabled, @EnabledInComps, @EnabledInTools)
END