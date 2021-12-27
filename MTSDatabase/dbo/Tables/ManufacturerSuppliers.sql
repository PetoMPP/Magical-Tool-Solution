CREATE TABLE [dbo].[ManufacturerSuppliers]
(
	[SupplierId] VARCHAR(20) NOT NULL,
	[ManufacturerId] VARCHAR(20) NOT NULL, 
	PRIMARY KEY([SupplierId], [ManufacturerId]),
    CONSTRAINT [FK_ManufacturerSuppliers_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers]([Id]),
    CONSTRAINT [FK_ManufacturerSuppliers_Manufacturers] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers]([Id]),

)
