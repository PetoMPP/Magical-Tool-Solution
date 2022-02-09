CREATE PROCEDURE [dbo].[spToolParameters_Insert]
	@ToolId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(12,6)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolParameters
	(ToolId, ParameterId, TextValue, NumericValue)
	VALUES 
	(@ToolId, @ParameterId, @TextValue, @NumericValue)
END