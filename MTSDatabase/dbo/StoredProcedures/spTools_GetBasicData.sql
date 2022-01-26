CREATE PROCEDURE [dbo].[spTools_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2
	FROM Tools
END
