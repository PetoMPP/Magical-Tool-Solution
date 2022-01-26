CREATE PROCEDURE [dbo].[spToolGroups_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name
	FROM ToolGroups
END
