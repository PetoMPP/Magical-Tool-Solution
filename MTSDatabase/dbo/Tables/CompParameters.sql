CREATE TABLE [dbo].[CompParameters]
(
	[CompId] VARCHAR(20) NOT NULL,
	[ParameterId] VARCHAR(20) NOT NULL,
	[TextValue] NVARCHAR(120) NULL,
	[NumericValue] NUMERIC(9,6) NULL, 
	PRIMARY KEY ([CompId], [ParameterId]),
    CONSTRAINT [FK_CompParameters_Comps] FOREIGN KEY ([CompId]) REFERENCES [Comps]([Id]),
    --CONSTRAINT [FK_CompParameters_ToolClassParameters] FOREIGN KEY ([ParameterId]) REFERENCES [ToolClassParameters]([Id])
)
