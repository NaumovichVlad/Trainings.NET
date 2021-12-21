SET NOCOUNT ON;
DECLARE @bigNumber INT = 1000,
		@smallNumber INT = 100,
		@symbol CHAR(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@textVar NVARCHAR(100),
		@position INT,
		@tmp int,
		@i INT,
		@j INT;

SET @i = 0;
WHILE @i < @smallNumber
	BEGIN 
		INSERT INTO dbo.Genres(Name)
			VALUES ('Genre_' + CAST((@i + 1) as varchar(10)));
		SET @i += 1;
	END

SET @i = 0;
WHILE @i < @smallNumber
	BEGIN 
		SET @j = 0
		SET @textVar = ''
		WHILE @j < 100
		BEGIN
			SET @position = RAND()*52
			SET @textVar += SUBSTRING(@symbol, @position, 1)
			SET @j += 1
		END
		INSERT INTO dbo.Authors(Surname, Name, MiddleName, Description)
			SELECT
			'Surname_' + CAST((@i + 1) as varchar(10)), 
			'Name_' + CAST((@i + 1) as varchar(10)),  
			'Middlename_' + CAST((@i + 1) as varchar(15)),
			@textVar;
		SET @i += 1;
	END

SET @i = 0;
WHILE @i < @smallNumber
	BEGIN
		SET @j = 0
		SET @textVar = ''
		WHILE @j < 100
		BEGIN
			SET @position = RAND()*52
			SET @textVar += SUBSTRING(@symbol, @position, 1)
			SET @j += 1
		END
		INSERT INTO dbo.Subscribers(Surname, Name, MiddleName, Gender, Address)
			SELECT
			'Surname_' + CAST((@i + 1) as varchar(10)), 
			'Name_' + CAST((@i + 1) as varchar(10)),  
			'Middlename_' + CAST((@i + 1) as varchar(15)),
			CAST(RAND() * 1 AS BIT),
			@textVar;
		SET @i += 1;
	END

SET @i = 0;
WHILE @i < @smallNumber
	BEGIN 
		INSERT INTO dbo.Orders(SubscriberId, OrderDate)
			SELECT 
			CAST((1 + RAND() * (@smallNumber - 1)) as int),
			DateAdd(MONTH, RAND() * 25, RAND() * 20000);
		SET @i += 1;
	END

SET @i = 0;
WHILE @i < @bigNumber
	BEGIN 
		SET @tmp = CAST((1 + RAND() * 3) as int);
		INSERT INTO dbo.Books(Title, AuthorId, GenreId, Condition)
			SELECT
			'Title_' + CAST((@i + 1) as varchar(10)),
			CAST((1 + RAND() * (@smallNumber - 1)) as int),
			CAST((1 + RAND() * (@smallNumber - 1)) as int),
			@tmp;
		INSERT INTO dbo.BooksInOrders(OrderId, BookId, ConditionAfterReturning, ConditionBeforeReceiving, IsReturned)
			SELECT
			CAST((1 + RAND() * (@smallNumber - 1)) as int),
			@i + 1,
			@tmp,
			@tmp,
			CAST(RAND() * 1 AS BIT);
		SET @i += 1;
	END
		