CREATE PROCEDURE [dbo].[spLists_Insert]
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
	INSERT INTO Lists
	(Id, Description1, Description2, MachineId, MachineGroupId, MaterialId, DataStatus, CreatorName, LastModifiedName, OwnerName)
	VALUES 
	(@Id, @Description1, @Description2, @MachineId, @MachineGroupId, @MaterialId, @DataStatus, @CreatorName, @LastModifiedName, @OwnerName)
END