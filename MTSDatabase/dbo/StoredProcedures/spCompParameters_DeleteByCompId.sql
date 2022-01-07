CREATE PROCEDURE [dbo].[spCompParameters_DeleteByCompId]
	@CompId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM CompParameters
	WHERE CompId = @CompId
END
