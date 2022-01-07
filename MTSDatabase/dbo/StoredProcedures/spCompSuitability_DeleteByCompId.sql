CREATE PROCEDURE [dbo].[spCompSuitability_DeleteByCompId]
	@CompId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM CompSuitability
	WHERE CompId = @CompId
END
