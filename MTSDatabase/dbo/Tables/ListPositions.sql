CREATE TABLE [dbo].[ListPositions]
(
	[ListId] VARCHAR(20) NOT NULL,
	[Position] INT NOT NULL,
	[CompId] VARCHAR(20) NULL,
	[ToolId] VARCHAR(20) NULL,
	[Quantity] INT NOT NULL, 
	PRIMARY KEY ([ListId], [Position]),
    CONSTRAINT [FK_ListPositions_Lists] FOREIGN KEY ([ListId]) REFERENCES [Lists]([Id]),
    CONSTRAINT [FK_ListPositions_Comps] FOREIGN KEY ([CompId]) REFERENCES [Comps]([Id]),
    CONSTRAINT [FK_ListPositions_Tools] FOREIGN KEY ([ToolId]) REFERENCES [Tools]([Id])
)
