CREATE PROCEDURE [dbo].[spLists_UpdateById]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120) = NULL,
	@MachineId VARCHAR(20) = NULL,
	@MachineGroupId VARCHAR(20) = NULL,
	@MaterialId VARCHAR(20) = NULL,
	@DataStatus NVARCHAR(120) = NULL,
	@CreatorName NVARCHAR(120) = NULL,
	@LastModifiedName NVARCHAR(120) = NULL,
	@OwnerName NVARCHAR(120) = NULL
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