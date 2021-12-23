using DataAccess.Enums;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class BooksInOrdersRepository : Repository<BooksInOrder>
    {
        public BooksInOrdersRepository(string connectionString)
            : base(connectionString)
        { }
        public override void Create(BooksInOrder booksInOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO BooksInOrders (BookId, OrderId, ConditionBeforeReceiving, ConditionAfterReturning, IsReturned) " +
                    "VALUES (@bookId, @orderId, @conditionBeforeReceiving, @conditionAfterReturning, @isReturned)";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@bookId", booksInOrder.BookId),
                    new SqlParameter("@orderId", booksInOrder.OrderId),
                    new SqlParameter("@conditionBeforeReceiving", booksInOrder.ConditionBeforeReceiving),
                    new SqlParameter("@conditionAfterReturning", booksInOrder.ConditionAfterReturning),
                    new SqlParameter("@isReturned", booksInOrder.IsReturned)
                });
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM BooksInOrders WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override BooksInOrder GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM BooksInOrders WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var booksInOrders = new BooksInOrder
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    BookId = Convert.ToInt32(reader["BookId"]),
                    OrderId = Convert.ToInt32(reader["OrderId"]),
                    ConditionBeforeReceiving = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["ConditionBeforeReceiving"])),
                    ConditionAfterReturning = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["ConditionAfterReturning"])),
                    IsReturned = bool.Parse(reader["IsReturned"].ToString())
                };
                return booksInOrders;
            }
        }

        public override List<BooksInOrder> GetList()
        {
            var booksInOrders = new List<BooksInOrder>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM BooksInOrders";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        booksInOrders.Add(new BooksInOrder
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookId = Convert.ToInt32(reader["BookId"]),
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            ConditionBeforeReceiving = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["ConditionBeforeReceiving"])),
                            ConditionAfterReturning = (Conditions)Enum.ToObject(typeof(Conditions), Convert.ToInt32(reader["ConditionAfterReturning"])),
                            IsReturned = bool.Parse(reader["IsReturned"].ToString())
                        });
                    }
                }
                return booksInOrders;
            }
        }

        public override void Update(BooksInOrder booksInOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE BooksInOrders SET BookId = @bookId, OrderId = @orderId, ConditionBeforeReceiving = @conditionBeforeReceiving, " +
                    "ConditionAfterReturning = @conditionAfterReturning, IsReturned = @isReturned " +
                    "FROM BooksInOrders WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", booksInOrder.Id),
                    new SqlParameter("@bookId", booksInOrder.BookId),
                    new SqlParameter("@orderId", booksInOrder.OrderId),
                    new SqlParameter("@conditionBeforeReceiving", booksInOrder.ConditionBeforeReceiving),
                    new SqlParameter("@conditionAfterReturning", booksInOrder.ConditionAfterReturning),
                    new SqlParameter("@isReturned", booksInOrder.IsReturned)
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
