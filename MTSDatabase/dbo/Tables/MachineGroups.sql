CREATE TABLE [dbo].[MachineGroups]
(
	[Id] VARCHAR(20) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(120) NOT NULL UNIQUE
)
