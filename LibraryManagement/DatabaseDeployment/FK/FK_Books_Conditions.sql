ALTER TABLE [dbo].[Books]
	ADD CONSTRAINT [FK_Books_Conditions]
	FOREIGN KEY (ConditionId)
	REFERENCES [Conditions] (Id)
