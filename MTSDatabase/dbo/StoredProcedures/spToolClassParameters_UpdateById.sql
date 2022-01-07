CREATE PROCEDURE [dbo].[spToolClassParameters_UpdateById]
	@Id VARCHAR(20),
	@ToolClassId VARCHAR(20),
	@Position INT,
	@Name NVARCHAR(120),
	@Description NVARCHAR(120),
	@DataValueType NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ToolClassParameters 
	SET 
	ToolClassId = @ToolClassId,
	Position = @Position,
	Name = @Name,
	Description = @Description,
	DataValueType = @DataValueType
	WHERE Id = @Id
END