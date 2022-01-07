CREATE PROCEDURE [dbo].[spToolSuitability_Update]
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
	UPDATE ToolSuitability
	SET PSuitability = @PSuitability,
	MSuitability = @MSuitability,
	KSuitability = @KSuitability,
	NSuitability = @NSuitability,
	SSuitability = @SSuitability,
	HSuitability = @HSuitability
	WHERE 
	ToolId = @ToolId
END