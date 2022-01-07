﻿CREATE PROCEDURE [dbo].[spToolGroups_GetByToolClassId]
	@ToolClassId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
	Id, Name, ToolClassId, SuitabilityEnabled, MachineInterfaceEnabled,
	InsertsEnabled, HoldingOtherComponentsEnabled, EnabledInComps, EnabledInTools
	FROM ToolGroups
	WHERE ToolClassId = @ToolClassId
END