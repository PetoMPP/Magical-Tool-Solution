CREATE TABLE [dbo].[ToolSuitability]
(
	[ToolId] VARCHAR(20) NOT NULL PRIMARY KEY,
	[PSuitability] INT NOT NULL,
	[MSuitability] INT NOT NULL,
	[KSuitability] INT NOT NULL,
	[NSuitability] INT NOT NULL,
	[SSuitability] INT NOT NULL,
	[HSuitability] INT NOT NULL
)
