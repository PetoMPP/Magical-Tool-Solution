CREATE PROCEDURE [dbo].[spTools_Update]
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
	UPDATE Tools
	SET Description1 = @Description1,
	Description2 = @Description2,
	ToolClassId = @ToolClassId,
	ToolGroupId = @ToolGroupId,
	MachineInterfaceId = @MachineInterfaceId,
	DataStatus = @DataStatus
	WHERE
	Id = @Id
END