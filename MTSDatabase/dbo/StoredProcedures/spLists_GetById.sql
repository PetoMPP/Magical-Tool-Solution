CREATE PROCEDURE [dbo].[spLists_GetById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
	Id, Description1, Description2, MachineId, MachineGroupId, MaterialId,
	DataStatus, CreatorName, LastModifiedName, OwnerName
	FROM Lists
	WHERE Id = @Id
END