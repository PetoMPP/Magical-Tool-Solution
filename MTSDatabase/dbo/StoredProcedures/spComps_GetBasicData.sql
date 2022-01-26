CREATE PROCEDURE [dbo].[spComps_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2
	FROM Comps
END
