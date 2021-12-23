using DataAccess.Enums;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class BooksRepository : Repository<Book>
    {
        public BooksRepository(string connectionString)
            : base(connectionString)
        { }
        public override void Create(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Books (Title, GenreId, AuthorId, Condition) " +
                    "VALUES (@title, @genreId, @authorId, @condition)";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@title", book.Title),
                    new SqlParameter("@genreId", book.GenreId),
                    new SqlParameter("@authorId", book.AuthorId),
                    new SqlParameter("@condition", book.Condition)
                });
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Books WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override Book GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Books WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var book = new Book
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    GenreId = Convert.ToInt32(reader["GenreId"]),
                    AuthorId = Convert.ToInt32(reader["AuthorId"]),
                    Condition = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["Condition"]))
                };
                return book;
            }
        }

        public override List<Book> GetList()
        {
            var books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Books";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            GenreId = Convert.ToInt32(reader["GenreId"]),
                            AuthorId = Convert.ToInt32(reader["AuthorId"]),
                            Condition = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["Condition"]))
                        });
                    }
                }
                return books;
            }
        }

        public override void Update(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE Books SET Title = @title, GenreId = @genreId, AuthorId = @authorId, Condition = @condition " +
                    "FROM Books WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", book.Id),
                    new SqlParameter("@title", book.Title),
                    new SqlParameter("@genreId", book.GenreId),
                    new SqlParameter("@authorId", book.AuthorId),
                    new SqlParameter("@condition", book.Condition)
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
