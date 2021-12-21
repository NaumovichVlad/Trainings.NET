ALTER TABLE [dbo].[BooksInOrders]
	ADD CONSTRAINT [FK_BooksInOrders_Orders]
	FOREIGN KEY (OrderId)
	REFERENCES [Orders] (Id)
