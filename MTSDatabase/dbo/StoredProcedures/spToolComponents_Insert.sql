CREATE PROCEDURE [dbo].[spToolComponents_Insert]
	@ToolId VARCHAR(20),
	@CompId VARCHAR(20),
	@Quantity INT,
	@Position INT,
	@IsKey BIT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolComponents
	(ToolId, CompId, Quantity, Position, IsKey)
	VALUES 
	(@ToolId, @CompId, @Quantity, @Position, @IsKey)
END