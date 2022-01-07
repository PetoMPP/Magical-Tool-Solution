﻿CREATE PROCEDURE [dbo].[spToolComponents_Update]
	@ToolId VARCHAR(20),
	@CompId VARCHAR(20),
	@Quantity INT,
	@Position INT,
	@IsKey BIT
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolComponents
	SET 
	CompId = @CompId,
	Quantity = @Quantity,
	Position = @Position,
	IsKey = @IsKey
	WHERE ToolId = @ToolId
END