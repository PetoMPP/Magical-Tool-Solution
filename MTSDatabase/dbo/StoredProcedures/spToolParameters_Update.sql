CREATE PROCEDURE [dbo].[spToolParameters_Update]
	@ToolId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(12,6)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolParameters
	SET 
	NumericValue = @NumericValue,
	TextValue = @TextValue
	WHERE 
	ToolId = @ToolId AND
	ParameterId = @ParameterId
END