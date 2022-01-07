CREATE PROCEDURE [dbo].[spTools_Insert]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120),
	@ToolClassId VARCHAR(20),
	@ToolGroupId VARCHAR(20),
	@MachineInterfaceId VARCHAR(20),
	@DataStatus NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Tools
	(Id, Description1, Description2, ToolClassId, ToolGroupId, MachineInterfaceId, DataStatus)
	VALUES 
	(@Id, @Description1, @Description2, @ToolClassId, @ToolGroupId, @MachineInterfaceId, @DataStatus)
END