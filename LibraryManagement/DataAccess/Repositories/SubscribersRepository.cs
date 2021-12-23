using DataAccess.Enums;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class SubscribersRepository : Repository<Subscriber>
    {
        public SubscribersRepository(string connectionString)
            : base(connectionString)
        { }
        public override void Create(Subscriber subscriber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Subscribers (Surname, Name, MiddleName, Gender, Address) " +
                    "VALUES (@surname, @name, @middleName, @gender, @address)";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@surname", subscriber.Surname),
                    new SqlParameter("@name", subscriber.Name),
                    new SqlParameter("@middleName", subscriber.MiddleName),
                    new SqlParameter("@gender", subscriber.Gender),
                    new SqlParameter("@address", subscriber.Address)
                });
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Subscribers WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override Subscriber GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Subscribers WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var subscriber = new Subscriber
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Surname = reader["Surname"].ToString(),
                    Name = reader["Name"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    Gender = (Genders)Enum.ToObject(typeof(Genders), Convert.ToInt32(reader["Gender"])),
                    Address = reader["Address"].ToString()
                };
                return subscriber;
            }
        }

        public override List<Subscriber> GetList()
        {
            var subscribers = new List<Subscriber>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Subscribers";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        subscribers.Add(new Subscriber
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Surname = reader["Surname"].ToString(),
                            Name = reader["Name"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            Gender = (Genders)Enum.ToObject(typeof(Genders), Convert.ToInt32(reader["Gender"])),
                            Address = reader["Address"].ToString()
                        });
                    }
                }
                return subscribers;
            }
        }

        public override void Update(Subscriber subscriber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE Subscribers SET Surname = @surname, Name = @name, MiddleName = @middleName, Gender = @gender, Address = @address " +
                    "FROM Subscribers WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", subscriber.Id),
                    new SqlParameter("@surname", subscriber.Surname),
                    new SqlParameter("@name", subscriber.Name),
                    new SqlParameter("@middleName", subscriber.MiddleName),
                    new SqlParameter("@gender", subscriber.Gender),
                    new SqlParameter("@address", subscriber.Address)
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
