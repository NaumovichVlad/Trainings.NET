using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class GenresRepository : Repository<Genre>
    {
        public GenresRepository(string connectionString)
            : base(connectionString)
        { }

        public override void Create(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Genres (Name) VALUES (@name)";
                var command = new SqlCommand(sqlExpression, connection);
                var nameParam = new SqlParameter("@name", genre.Name);
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Genres WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override Genre GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Genres WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var genre = new Genre
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()
                };
                return genre;
            }
        }

        public override List<Genre> GetList()
        {
            var genres = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Genres";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        genres.Add(new Genre
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }
            return genres;
        }

        public override void Update(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE Genres SET Name = @name " +
                    "FROM Genres WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", genre.Id),
                    new SqlParameter("@name", genre.Name)
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
