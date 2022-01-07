CREATE PROCEDURE [dbo].[spManufacturers_GetNameById]
	@Id VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Name
	FROM Manufacturers
	WHERE Id = @Id
END