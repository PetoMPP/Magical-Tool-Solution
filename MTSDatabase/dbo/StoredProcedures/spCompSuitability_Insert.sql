CREATE PROCEDURE [dbo].[spCompSuitability_Insert]
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
	INSERT INTO CompSuitability
	(CompId, PSuitability, MSuitability, KSuitability, NSuitability, SSuitability, HSuitability)
	VALUES 
	(@CompId, @PSuitability, @MSuitability, @KSuitability, @NSuitability, @SSuitability, @HSuitability)
END