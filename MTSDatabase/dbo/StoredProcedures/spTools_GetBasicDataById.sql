CREATE PROCEDURE [dbo].[spTools_GetBasicDataById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2 FROM Tools
	WHERE Id = @Id
END
