CREATE PROCEDURE [dbo].[spLists_Insert]
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
	INSERT INTO Lists
	(Id, Description1, Description2, MachineId, MachineGroupId, MaterialId, DataStatus, CreatorName, LastModifiedName, OwnerName)
	VALUES 
	(@Id, @Description1, @Description2, @MachineId, @MachineGroupId, @MaterialId, @DataStatus, @CreatorName, @LastModifiedName, @OwnerName)
END