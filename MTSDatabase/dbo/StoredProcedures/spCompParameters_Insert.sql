CREATE PROCEDURE [dbo].[spCompParameters_Insert]
	@CompId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(9,6)
AS
BEGIN
	SET NOCOUNT ON
	IF (@TextValue != NULL)
		BEGIN
		INSERT INTO CompParameters
		(CompId, ParameterId, TextValue)
		VALUES 
		(@CompId, @ParameterId, @TextValue)
		END
	ELSE
		BEGIN
		INSERT INTO CompParameters
		(CompId, ParameterId, NumericValue)
		VALUES 
		(@CompId, @ParameterId, @NumericValue)
		END
END