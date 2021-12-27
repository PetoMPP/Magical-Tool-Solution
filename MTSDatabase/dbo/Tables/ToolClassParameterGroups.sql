CREATE TABLE [dbo].[ToolClassParameterGroups]
(
	[ToolClassId] VARCHAR(20) NOT NULL,
	[ParameterId] VARCHAR(20) NOT NULL,
	[ToolGroupId] VARCHAR(20) NOT NULL,
	PRIMARY KEY ([ToolClassId], [ToolGroupId], [ParameterId]), 
    CONSTRAINT [FK_ToolClassParameterGroups_ToolGroups] FOREIGN KEY ([ToolClassId], [ToolGroupId]) REFERENCES [ToolGroups]([ToolClassId], [Id]),
)
