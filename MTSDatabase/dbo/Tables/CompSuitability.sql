CREATE TABLE [dbo].[CompSuitability]
(
	[CompId] VARCHAR(20) NOT NULL PRIMARY KEY,
	[PSuitability] INT NOT NULL,
	[MSuitability] INT NOT NULL,
	[KSuitability] INT NOT NULL,
	[NSuitability] INT NOT NULL,
	[SSuitability] INT NOT NULL,
	[HSuitability] INT NOT NULL, 
    CONSTRAINT [FK_CompSuitability_Comps] FOREIGN KEY ([CompId]) REFERENCES [Comps]([Id])
)
