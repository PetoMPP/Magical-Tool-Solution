CREATE PROCEDURE [dbo].[spGetCompParameters_ByCompIdToolClassId]
	@CompId VARCHAR(20),
	@ToolClassId VARCHAR(20)
AS
	BEGIN
	SET NOCOUNT ON
	SELECT a.Position, a.Id AS ParameterId, a.Name, a.Description, a.DataValueType, b.NumericValue, b.TextValue
	FROM ToolClassParameters a
	INNER JOIN CompParameters b ON a.Id = b.ParameterId
	WHERE a.ToolClassId = @ToolClassId AND b.CompId = @CompId
END