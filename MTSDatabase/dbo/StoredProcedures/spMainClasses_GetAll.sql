﻿CREATE PROCEDURE [dbo].[spMainClasses_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Name
	FROM MainClasses
END