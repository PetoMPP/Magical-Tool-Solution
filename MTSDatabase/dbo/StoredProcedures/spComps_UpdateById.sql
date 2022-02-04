CREATE PROCEDURE [dbo].[spComps_UpdateById]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120) = NULL,
	@ToolClassId VARCHAR(20),
	@ToolGroupId VARCHAR(20),
	@ManufacturerName NVARCHAR(120) = NULL,
	@DataStatus NVARCHAR(120) = NULL
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Comps
	SET 
	Description1 = @Description1,
	Description2 = @Description2,
	ToolClassId = @ToolClassId,
	ToolGroupId = @ToolGroupId,
	ManufacturerName = @ManufacturerName,
	DataStatus = @DataStatus
	WHERE Id = @Id
END