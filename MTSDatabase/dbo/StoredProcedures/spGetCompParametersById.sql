CREATE PROCEDURE [dbo].[spGetCompParametersById]
	@CompId VARCHAR(20)
AS
SELECT a.Id, d.NumericValue, d.TextValue
	FROM ToolClassParameters as a
	JOIN ToolClassParameterGroups as b ON a.ToolClassId = b.ToolClassId
	full JOIN Comps AS c on c.Id = a.Id
	full JOIN CompParameters as d on d.CompId = a.Id
	where d.CompId = @CompId