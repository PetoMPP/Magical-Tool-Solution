CREATE TABLE [dbo].[MachineMachineGroups]
(
	[MachineId] VARCHAR(20) NOT NULL,
	[MachineGroupId] VARCHAR(20) NOT NULL,
	PRIMARY KEY ([MachineId], [MachineGroupId]), 
    CONSTRAINT [FK_MachineMachineGroups_Machines] FOREIGN KEY ([MachineId]) REFERENCES [Machines]([Id]),
    CONSTRAINT [FK_MachineMachineGroups_MachineGroups] FOREIGN KEY ([MachineGroupId]) REFERENCES [MachineGroups]([Id])
)
