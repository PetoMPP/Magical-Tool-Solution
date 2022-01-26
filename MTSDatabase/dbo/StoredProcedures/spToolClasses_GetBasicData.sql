CREATE PROCEDURE [dbo].[spToolClasses_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name
	FROM ToolClasses
END
