using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(string connectionString)
            : base(connectionString)
        { }

        public override void Create(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Orders (SubscriberId, OrderDate) " +
                    "VALUES (@subscriberId, @orderDate)";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@subscriberId", order.SubscriberId),
                    new SqlParameter("@orderDate", order.OrderDate),
                });
                command.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Orders WHERE Id = @id)";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public override Order GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Orders WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                reader.Read();
                var order = new Order
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    SubscriberId = Convert.ToInt32(reader["SubscriberId"]),
                    OrderDate = DateTime.Parse(reader["OrderDate"].ToString())
                };
                return order;
            }
        }

        public override List<Order> GetList()
        {
            var orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Orders";
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SubscriberId = Convert.ToInt32(reader["SubscriberId"]),
                            OrderDate = DateTime.Parse(reader["OrderDate"].ToString())
                        });
                    }
                }
                return orders;
            }
        }

        public override void Update(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "UPDATE Orders SET SubscriberId = @subscriberId, OrderDate = @orderDate " +
                    "FROM Orders WHERE Id = @id";
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", order.Id),
                    new SqlParameter("@subscriberId", order.SubscriberId),
                    new SqlParameter("@orderDate", order.OrderDate),
                });
                command.ExecuteNonQuery();
            }
        }
    }
}
