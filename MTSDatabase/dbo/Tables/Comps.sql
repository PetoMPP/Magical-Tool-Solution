CREATE TABLE [dbo].[Comps]
(
	[Id] VARCHAR(20) NOT NULL,
	[Description1] NVARCHAR(120) NOT NULL,
	[Description2] NVARCHAR(120) NULL,
	[ToolClassId] VARCHAR(20) NOT NULL,
	[ToolGroupId] VARCHAR(20) NOT NULL,
	[ManufacturerName] NVARCHAR(120) NULL,
	[MachineInterfaceName] NVARCHAR(120) NULL,
	[DataStatus] NVARCHAR(120) NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Comps_Manufacturers] FOREIGN KEY ([ManufacturerName]) REFERENCES [Manufacturers]([Name]),
    CONSTRAINT [FK_Comps_ToolGroups] FOREIGN KEY ([ToolClassId], [ToolGroupId]) REFERENCES [ToolGroups]([ToolClassId], [Id]),
	CONSTRAINT [FK_Comps_DataStatuses] FOREIGN KEY ([DataStatus]) REFERENCES [DataStatuses]([Name]),
	CONSTRAINT [FK_Comps_MachineInterfaces] FOREIGN KEY ([MachineInterfaceName]) REFERENCES [MachineInterfaces]([Name])
)
