CREATE TABLE [dbo].[Tools]
(
	[Id] VARCHAR(20) NOT NULL PRIMARY KEY,
	[Description1] NVARCHAR(120) NOT NULL,
	[Description2] NVARCHAR(120) NULL,
	[ToolClassId] VARCHAR(20) NOT NULL,
	[ToolGroupId] VARCHAR(20) NOT NULL,
	[MachineInterfaceName] NVARCHAR(120) NULL,
	[DataStatus] NVARCHAR(120) NULL, 
    CONSTRAINT [FK_Tools_MachineInterfaces] FOREIGN KEY ([MachineInterfaceName]) REFERENCES [MachineInterfaces]([Name]),
    CONSTRAINT [FK_Tools_ToolGroups] FOREIGN KEY ([ToolClassId], [ToolGroupId]) REFERENCES [ToolGroups]([ToolClassId], [Id]),
	CONSTRAINT [FK_Tools_DataStatuses] FOREIGN KEY ([DataStatus]) REFERENCES [DataStatuses]([Name])
)