CREATE PROCEDURE [dbo].[spCompSuitability_GetByCompId]
	@CompId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT CompId, PSuitability, MSuitability, KSuitability, 
	NSuitability, SSuitability, HSuitability
	FROM CompSuitability
	WHERE CompId = @CompId
END