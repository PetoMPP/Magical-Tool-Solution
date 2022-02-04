CREATE PROCEDURE [dbo].[spToolGroups_GetById]
	@Id VARCHAR(20),
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
	Id, Name, ToolClassId, SuitabilityEnabled, MachineInterfaceEnabled,
	InsertsEnabled, HoldingOtherComponentsEnabled, EnabledInComps, EnabledInTools
	FROM ToolGroups
	WHERE Id = @Id AND ToolClassId = @ToolClassId
END