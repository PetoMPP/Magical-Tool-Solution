﻿CREATE PROCEDURE [dbo].[spToolClasses_DeleteById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM ToolClasses
	WHERE Id = @Id
END
