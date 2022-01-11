CREATE PROCEDURE [dbo].[spToolGroups_Update]
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
	UPDATE ToolGroups
	SET
	Name = @Name,
	ToolClassId = @ToolClassId,
	SuitabilityEnabled = @SuitabilityEnabled,
	MachineInterfaceEnabled = @MachineInterfaceEnabled,
	InsertsEnabled = @InsertsEnabled,
	HoldingOtherComponentsEnabled = @HoldingOtherComponentsEnabled,
	EnabledInComps = @EnabledInComps,
	EnabledInTools = @EnabledInTools
	WHERE Id = @Id
END