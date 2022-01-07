CREATE PROCEDURE [dbo].[spComps_GetBasicDataById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, Description1, Description2 FROM Comps
	WHERE Id = @Id
END
