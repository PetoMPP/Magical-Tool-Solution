CREATE PROCEDURE [dbo].[spToolClasses_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name, MainClassId FROM ToolClasses
END