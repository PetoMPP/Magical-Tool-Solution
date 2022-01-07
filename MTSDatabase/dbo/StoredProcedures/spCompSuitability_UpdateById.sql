CREATE PROCEDURE [dbo].[spCompSuitability_UpdateById]
	@CompId VARCHAR(20),
	@PSuitability INT,
	@MSuitability INT,
	@KSuitability INT,
	@NSuitability INT,
	@SSuitability INT,
	@HSuitability INT
AS
BEGIN
	SET NOCOUNT ON
	UPDATE CompSuitability
	SET 
	PSuitability = @PSuitability,
	MSuitability = @MSuitability,
	KSuitability = @KSuitability,
	NSuitability = @NSuitability,
	SSuitability = @SSuitability,
	HSuitability = @SSuitability
	WHERE CompId = @CompId
END