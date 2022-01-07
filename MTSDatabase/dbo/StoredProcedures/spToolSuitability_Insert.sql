CREATE PROCEDURE [dbo].[spToolSuitability_Insert]
	@ToolId VARCHAR(20),
	@PSuitability INT,
	@MSuitability INT,
	@KSuitability INT,
	@NSuitability INT,
	@SSuitability INT,
	@HSuitability INT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolSuitability
	(ToolId, PSuitability, MSuitability, KSuitability, NSuitability, SSuitability, HSuitability)
	VALUES 
	(@ToolId, @PSuitability, @MSuitability, @KSuitability, @NSuitability, @SSuitability, @HSuitability)
END