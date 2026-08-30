using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TestAQA3.DTO;
using Tests1.DTO.DapperTestsDTO;
using Tests1.Interfaces.DapperTestsInterfaces;

namespace Tests1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;
        public ProductRepository(string connection)
        {
            this.connection = connection;
        }
        public async Task<ProductDTO> GetProductById(int productId)
        {
            using var db = new SqliteConnection(connection);
            var productById = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * from Products " +
                "WHERE Id = @productId", new { productId });
            return productById;
        }
    }
}
