﻿CREATE PROCEDURE [dbo].[spToolGroups_GetNameById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Name
	FROM ToolGroups
	WHERE Id = @Id
END