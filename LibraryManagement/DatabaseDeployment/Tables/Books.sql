CREATE TABLE [dbo].[Books] (
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(MAX) NOT NULL,
	[AuthorId] INT NOT NULL,
	[GenreId] INT NOT NULL,
	[YearOfPuplication] INT NOT NULL,
	[Description] NVARCHAR(MAX),
	[ConditionId] INT NOT NULL,
)
