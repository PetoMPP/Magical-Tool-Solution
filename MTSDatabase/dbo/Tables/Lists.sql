CREATE TABLE [dbo].[Lists]
(
	[Id] VARCHAR(20) NOT NULL PRIMARY KEY,
	[Description1] NVARCHAR(120) NOT NULL,
	[Description2] NVARCHAR(120) NULL,
	[MachineId] VARCHAR(20) NULL,
	[MachineGroupId] VARCHAR(20) NULL,
	[MaterialId] VARCHAR(20) NULL,
	[DataStatus] NVARCHAR(120) NULL, 
	[CreatorName] NVARCHAR(120) NULL, 
	[LastModifiedName] NVARCHAR(120) NULL, 
	[OwnerName] NVARCHAR(120) NULL, 
    CONSTRAINT [FK_Lists_MachineMachineGroups] FOREIGN KEY ([MachineId], [MachineGroupId]) REFERENCES [MachineMachineGroups]([MachineId], [MachineGroupId]),
    CONSTRAINT [FK_Lists_Materials] FOREIGN KEY ([MaterialId]) REFERENCES [Materials]([Id]),
	CONSTRAINT [FK_Lists_DataStatuses] FOREIGN KEY ([DataStatus]) REFERENCES [DataStatuses]([Name]),
)
