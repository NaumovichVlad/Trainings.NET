CREATE TABLE [dbo].[BooksInOrders] (
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[OrderId] INT NOT NULL,
	[BookId] INT NOT NULL,
	[ConditionBeforeReceiving] INT NOT NULL,
	[ConditionAfterReturning] INT,
	[IsReturned] BIT NOT NULL
);
