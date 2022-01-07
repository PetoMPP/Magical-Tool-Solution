CREATE PROCEDURE [dbo].[spComps_Insert]
	@Id VARCHAR(20),
	@Description1 NVARCHAR(120),
	@Description2 NVARCHAR(120),
	@ToolClassId VARCHAR(20),
	@ToolGroupId VARCHAR(20),
	@ManufacturerName NVARCHAR(120),
	@DataStatus NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Comps
	(Id, Description1, Description2, ToolClassId, ToolGroupId, ManufacturerName, DataStatus)
	VALUES 
	(@Id, @Description1, @Description2, @ToolClassId, @ToolGroupId, @ManufacturerName, @DataStatus)
END