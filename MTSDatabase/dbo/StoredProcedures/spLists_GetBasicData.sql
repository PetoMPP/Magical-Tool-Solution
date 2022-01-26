CREATE PROCEDURE [dbo].[spLists_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2
	FROM Lists
END
