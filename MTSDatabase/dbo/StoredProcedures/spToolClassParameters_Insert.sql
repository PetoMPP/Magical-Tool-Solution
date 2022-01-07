CREATE PROCEDURE [dbo].[spToolClassParameters_Insert]
	@Id VARCHAR(20),
	@ToolClassId VARCHAR(20),
	@Position INT,
	@Name NVARCHAR(120),
	@Description NVARCHAR(120),
	@DataValueType NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO ToolClassParameters 
	(Id, ToolClassId, Position, Name, Description, DataValueType)
	VALUES 
	(@Id, @ToolClassId, @Position, @Name, @Description, @DataValueType)
END