CREATE PROCEDURE [dbo].[spCompParameters_UpdateById]
	@CompId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(12,6)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE CompParameters
	SET 
	NumericValue = @NumericValue,
	TextValue = @TextValue
	WHERE 
	CompId = @CompId AND
	ParameterId = @ParameterId
END