CREATE TABLE [dbo].[Comps]
(
	[Id] VARCHAR(20) NOT NULL,
	[Description1] NVARCHAR(120) NOT NULL,
	[Description2] NVARCHAR(120) NULL,
	[ToolClassId] VARCHAR(20) NOT NULL,
	[ToolGroupId] VARCHAR(20) NOT NULL,
	[ManufacturerName] NVARCHAR(120) NULL,
	[DataStatus] NVARCHAR(120) NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Components_Manufacturers] FOREIGN KEY ([ManufacturerName]) REFERENCES [Manufacturers]([Name]),
    CONSTRAINT [FK_Components_ToolGroups] FOREIGN KEY ([ToolClassId], [ToolGroupId]) REFERENCES [ToolGroups]([ToolClassId], [Id]),
	CONSTRAINT [FK_Components_DataStatuses] FOREIGN KEY ([DataStatus]) REFERENCES [DataStatuses]([Name])
)
