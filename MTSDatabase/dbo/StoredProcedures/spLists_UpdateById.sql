CREATE PROCEDURE [dbo].[spLists_UpdateById]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120),
	@MachineId VARCHAR(20),
	@MachineGroupId VARCHAR(20),
	@MaterialId VARCHAR(20),
	@DataStatus NVARCHAR(120),
	@CreatorName NVARCHAR(120),
	@LastModifiedName NVARCHAR(120),
	@OwnerName NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Lists
	SET 
	Description1 = @Description1,
	Description2 = @Description2,
	MachineId = @MachineId,
	MachineGroupId = @MachineGroupId,
	MaterialId = @MaterialId,
	DataStatus = @DataStatus,
	CreatorName = @CreatorName,
	LastModifiedName = @LastModifiedName,
	OwnerName = @OwnerName
	WHERE Id = @Id
END