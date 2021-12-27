CREATE TABLE [dbo].[ToolClassParameters]
(
	[Id] VARCHAR(20) NOT NULL,
	[ToolClassId] VARCHAR(20) NOT NULL,
	[Position] INT NOT NULL,
	[Name] NVARCHAR(120) NOT NULL,
	[Description] NVARCHAR(120) NOT NULL,
	[DataValueType] NVARCHAR(120) NOT NULL,
	PRIMARY KEY ([Id], [ToolClassId], [Position]), 
    CONSTRAINT [FK_ToolClassParameters_ToolClasses] FOREIGN KEY ([ToolClassId]) REFERENCES [ToolClasses]([Id]), 
    CONSTRAINT [FK_ToolClassParameters_DataValueTypes] FOREIGN KEY ([DataValueType]) REFERENCES [DataValueTypes]([Name])
)
