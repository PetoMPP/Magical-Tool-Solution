CREATE PROCEDURE [dbo].[spToolParameters_Insert]
	@ToolId VARCHAR(20),
	@ParameterId VARCHAR(20),
	@TextValue NVARCHAR(120),
	@NumericValue NUMERIC(9,6)
AS
BEGIN
	SET NOCOUNT ON
	IF (@TextValue != NULL)
		BEGIN
		INSERT INTO ToolParameters
		(ToolId, ParameterId, TextValue)
		VALUES 
		(@ToolId, @ParameterId, @TextValue)
		END
	ELSE
		BEGIN
		INSERT INTO ToolParameters
		(ToolId, ParameterId, NumericValue)
		VALUES 
		(@ToolId, @ParameterId, @NumericValue)
		END
END