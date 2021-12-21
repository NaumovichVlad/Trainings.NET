ALTER TABLE [dbo].[Books]
	ADD CONSTRAINT [FK_Books_Authors]
	FOREIGN KEY (AuthorId)
	REFERENCES [Authors] (Id)
