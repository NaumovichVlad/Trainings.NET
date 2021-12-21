ALTER TABLE [dbo].[Orders]
	ADD CONSTRAINT [FK_Orders_Subscribers]
	FOREIGN KEY (SubscriberId)
	REFERENCES [Subscribers] (Id)
