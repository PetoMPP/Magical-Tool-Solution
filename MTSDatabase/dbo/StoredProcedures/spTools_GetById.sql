CREATE PROCEDURE [dbo].[spTools_GetById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2, ToolClassId, ToolGroupId, MachineInterfaceName, DataStatus 
	FROM Tools
	WHERE Id = @Id
END