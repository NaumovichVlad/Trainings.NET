ALTER TABLE [dbo].[BooksInOrders]
	ADD CONSTRAINT [FK_BooksInOrders_Conditions_After]
	FOREIGN KEY (ConditionIdBeforeReceiving)
	REFERENCES [Conditions] (Id)
