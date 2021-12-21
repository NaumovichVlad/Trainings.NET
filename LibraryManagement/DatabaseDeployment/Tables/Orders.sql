CREATE TABLE [dbo].[Orders] (
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[SubscriberId] INT NOT NULL,
	[OrderDate] DATE NOT NULL
)
