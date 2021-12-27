CREATE TABLE [dbo].[Suppliers]
(
	[Id] VARCHAR(20) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL UNIQUE,
	[ContactPersonId] VARCHAR(20) NULL, 
    CONSTRAINT [FK_Suppliers_ContactPeople] FOREIGN KEY ([ContactPersonId]) REFERENCES [ContactPeople]([Id])
)
