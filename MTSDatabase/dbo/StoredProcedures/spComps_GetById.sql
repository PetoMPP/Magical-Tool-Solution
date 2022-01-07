CREATE PROCEDURE [dbo].[spComps_GetById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
	Id, Description1, Description2, ToolClassId, ToolGroupId, ManufacturerName, DataStatus
	FROM Comps
	WHERE Id = @Id
END
