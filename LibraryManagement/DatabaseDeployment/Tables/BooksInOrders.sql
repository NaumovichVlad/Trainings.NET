CREATE TABLE [dbo].[BooksInOrders] (
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[OrderId] INT NOT NULL,
	[BookId] INT NOT NULL,
	[ConditionIdBeforeReceiving] INT NOT NULL,
	[ConditionIdAfterReturning] INT,
	[IsReturned] BIT NOT NULL
);
