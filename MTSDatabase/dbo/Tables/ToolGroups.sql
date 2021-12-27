CREATE TABLE [dbo].[ToolGroups]
(
	[Id] VARCHAR(20) NOT NULL,
	[Name] NVARCHAR(120) NOT NULL,
	[ToolClassId] VARCHAR(20) NOT NULL,
	[SuitabilityEnabled] BIT NOT NULL,
	[MachineInterfaceEnabled] BIT NOT NULL,
	[InsertsEnabled] BIT NOT NULL,
	[HoldingOtherComponentsEnabled] BIT NOT NULL,
	[EnabledInComps] BIT NOT NULL,
	[EnabledInTools] BIT NOT NULL,
	PRIMARY KEY ([ToolClassId], [Id]), 
    CONSTRAINT [FK_ToolGroups_ToolClasses] FOREIGN KEY ([ToolClassId]) REFERENCES [ToolClasses]([Id])
)
