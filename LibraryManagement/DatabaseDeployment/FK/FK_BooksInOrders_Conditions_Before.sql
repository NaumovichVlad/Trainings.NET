ALTER TABLE [dbo].[BooksInOrders]
	ADD CONSTRAINT [FK_BooksInOrders_Conditions_Before]
	FOREIGN KEY (ConditionIdBeforeReceiving)
	REFERENCES [Conditions] (Id)
