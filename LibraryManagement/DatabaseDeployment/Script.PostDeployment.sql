
INSERT INTO dbo.Genres(Name)
	VALUES ('Genre_1'),
		   ('Genre_2'),
		   ('Genre_3'),
		   ('Genre_4'),
		   ('Genre_5')

INSERT INTO dbo.Authors(Surname, Name, MiddleName, Description)
	VALUES
		('Surname_1', 'Name_1', 'Middlename_1', 'Some text'),
		('Surname_2', 'Name_2', 'Middlename_2', 'Some text'),
		('Surname_3', 'Name_3', 'Middlename_3', 'Some text'),
		('Surname_4', 'Name_4', 'Middlename_4', 'Some text'),
		('Surname_5', 'Name_5', 'Middlename_5', 'Some text')


INSERT INTO dbo.Subscribers(Surname, Name, MiddleName, Gender, Address)
	VALUES 
		('Surname_1', 'Name_1', 'Middlename_1', 0, 'Address_1'),
		('Surname_2', 'Name_2', 'Middlename_2', 0, 'Address_2'),
		('Surname_3', 'Name_3', 'Middlename_3', 1, 'Address_3'),
		('Surname_4', 'Name_4', 'Middlename_4', 0, 'Address_4'),
		('Surname_5', 'Name_5', 'Middlename_5', 0, 'Address_5'),
		('Surname_6', 'Name_6', 'Middlename_6', 1, 'Address_6'),
		('Surname_7', 'Name_7', 'Middlename_7', 0, 'Address_7'),
		('Surname_8', 'Name_8', 'Middlename_8', 1, 'Address_8'),
		('Surname_9', 'Name_9', 'Middlename_9', 0, 'Address_9'),
		('Surname_10', 'Name_10', 'Middlename_10', 0, 'Address_10')

INSERT INTO dbo.Orders(SubscriberId, OrderDate)
	VALUES 
	(1, '2021.12.23'),
	(3, '2021.12.21'),
	(2, '2021.12.12'),
	(4, '2021.12.10'),
	(6, '2021.12.11'),
	(5, '2021.12.20'),
	(8, '2021.12.01'),
	(9, '2021.12.05'),
	(7, '2021.12.08'),
	(1, '2021.12.09'),
	(2, '2021.12.09'),
	(3, '2021.12.02'),
	(5, '2021.12.01'),
	(4, '2021.12.12'),
	(6, '2021.12.02'),
	(7, '2021.12.15'),
	(10, '2021.12.14'),
	(10, '2021.12.15'),
	(3, '2021.12.18'),
	(2, '2021.12.19')



INSERT INTO dbo.Books(Title, AuthorId, GenreId, Condition)
	VALUES
	('Title_1', 1, 2, 0),
	('Title_2', 2, 1, 0),
	('Title_3', 3, 4, 0),
	('Title_4', 4, 3, 0),
	('Title_5', 5, 5, 1),
	('Title_6', 1, 2, 0),
	('Title_7', 2, 1, 0),
	('Title_8', 3, 3, 1),
	('Title_9', 4, 5, 0),
	('Title_10', 5, 4, 0),
	('Title_11', 1, 3, 0),
	('Title_12', 2, 2, 1),
	('Title_13', 3, 1, 0),
	('Title_14', 4, 5, 0),
	('Title_15', 5, 4, 1),
	('Title_16', 1, 3, 0)

INSERT INTO dbo.BooksInOrders(OrderId, BookId, ConditionAfterReturning, ConditionBeforeReceiving, IsReturned)
	VALUES
		(1, 3, 0, 1, 0),
		(1, 1, 0, 1, 0),
		(2, 2, 0, 1, 1),
		(2, 4, 0, 1, 1),
		(3, 2, 0, 1, 0),
		(3, 4, 0, 1, 0),
		(4, 5, 0, 1, 1),
		(4, 6, 0, 1, 1),
		(5, 7, 0, 1, 1),
		(5, 8, 0, 1, 1),
		(6, 1, 0, 1, 1),
		(6, 4, 0, 1, 1),
		(7, 6, 0, 1, 1),
		(7, 7, 0, 1, 1),
		(8, 8, 0, 1, 1),
		(8, 9, 0, 1, 1),
		(9, 10, 0, 1, 1),
		(9, 6, 0, 1, 1),
		(10, 4, 0, 1, 1),
		(10, 5, 0, 1, 1)