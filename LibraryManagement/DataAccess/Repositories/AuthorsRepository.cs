using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class AuthorsRepository : Repository<Author>
    {
        public AuthorsRepository(string connectionString)
            : base(connectionString)
        { }

        public override void Create(Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Authors (Surname, Name, MiddleName, Description) " +
                    "VALUES (@surname, @name, @middleName, @description)";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@surname", author.Surname),
                    new SqlParameter("@name", author.Name),
                    new SqlParameter("@middleName", author.MiddleName),
                    new SqlParameter("@description", author.Description)
                });
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Authors WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override Author GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Authors WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var author = new Author
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Surname = reader["Surname"].ToString(),
                    Name = reader["Name"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    Description = reader["Description"].ToString()
                };
                return author;
            }
        }

        public override List<Author> GetList()
        {
            var authors = new List<Author>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Authors";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Surname = reader["Surname"].ToString(),
                            Name = reader["Name"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
                return authors;
            }
        }

        public override void Update(Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE Authors SET Surname = @surname, Name = @name, MiddleName = @middleName, Description = @description " +
                    "FROM Authors WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", author.Id),
                    new SqlParameter("@surname", author.Surname),
                    new SqlParameter("@name", author.Name),
                    new SqlParameter("@middleName", author.MiddleName),
                    new SqlParameter("@description", author.Description)
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
