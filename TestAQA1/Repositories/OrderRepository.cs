using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connection;
        public OrderRepository(string connection)
        {
            this.connection = connection;
        }
        public async Task<OrderDTO> GetOrderByOrderId(int orderId)
        {
            using var db = new SqliteConnection(connection);
            var ordersById = await db.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * from Orders " +
                "WHERE UserId = @orderId", new { orderId });
            return ordersById;
        }
    }
}
