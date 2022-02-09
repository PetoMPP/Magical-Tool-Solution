CREATE PROCEDURE [dbo].[spTools_Insert]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120) = NULL,
	@ToolClassId VARCHAR(20),
	@ToolGroupId VARCHAR(20),
	@MachineInterfaceName VARCHAR(20) = NULL,
	@DataStatus NVARCHAR(120) = NULL
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Tools
	(Id, Description1, Description2, ToolClassId, ToolGroupId, MachineInterfaceName, DataStatus)
	VALUES 
	(@Id, @Description1, @Description2, @ToolClassId, @ToolGroupId, @MachineInterfaceName, @DataStatus)
END