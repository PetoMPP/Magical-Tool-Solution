CREATE PROCEDURE [dbo].[spCompParameters_Insert]
	@CompId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(12,6)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO CompParameters
	(CompId, ParameterId, TextValue, NumericValue)
	VALUES 
	(@CompId, @ParameterId, @TextValue, @NumericValue)
END