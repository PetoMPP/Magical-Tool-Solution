CREATE TABLE [dbo].[ToolParameters]
(
	[ToolId] VARCHAR(20) NOT NULL,
	[ParameterId] VARCHAR(20) NOT NULL,
	[TextValue] NVARCHAR(120) NULL,
	[NumericValue] NUMERIC(9,6) NULL,
	PRIMARY KEY ([ToolId], [ParameterId]), 
    CONSTRAINT [FK_ToolParameters_Tools] FOREIGN KEY ([ToolId]) REFERENCES [Tools]([Id])
)
