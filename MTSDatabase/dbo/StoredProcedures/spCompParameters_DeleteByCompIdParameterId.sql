CREATE PROCEDURE [dbo].[spCompParameters_DeleteByCompIdParameterId]
	@CompId VARCHAR(20),
	@ParameterId VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM CompParameters
	WHERE CompId = @CompId AND ParameterId = @ParameterId
END
