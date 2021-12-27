CREATE TABLE [dbo].[ToolComponents]
(
	[ToolId] VARCHAR(20) NOT NULL,
	[CompId] VARCHAR(20) NOT NULL,
	[Quantity] INT NOT NULL DEFAULT 1,
	[Position] INT NOT NULL,
	[IsKey] BIT NOT NULL,
	PRIMARY KEY ([ToolId], [CompId], [Position]), 
    CONSTRAINT [FK_ToolComponents_Tools] FOREIGN KEY ([ToolId]) REFERENCES [Tools]([Id]),
    CONSTRAINT [FK_ToolComponents_Comps] FOREIGN KEY ([CompId]) REFERENCES [Comps]([Id])
)
