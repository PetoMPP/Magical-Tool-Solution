CREATE PROCEDURE [dbo].[spMainClasses_GetBasicData]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name
	FROM MainClasses
END
