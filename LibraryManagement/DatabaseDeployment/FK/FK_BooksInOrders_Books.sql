ALTER TABLE [dbo].[BooksInOrders]
	ADD CONSTRAINT [FK_BooksInOrders_Books]
	FOREIGN KEY (BookId)
	REFERENCES [Books] (Id)
