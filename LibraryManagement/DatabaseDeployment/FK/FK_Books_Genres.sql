ALTER TABLE [dbo].[Books]
	ADD CONSTRAINT [FK_Books_Genres]
	FOREIGN KEY (GenreId)
	REFERENCES [Genres] (Id)
