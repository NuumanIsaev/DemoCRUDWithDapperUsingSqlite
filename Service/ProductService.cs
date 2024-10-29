using Dapper;
using DemoCRUDwithDapperUsingSqlite.IService;
using DemoCRUDwithDapperUsingSqlite.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DemoCRUDwithDapperUsingSqlite.Service
{
    public class ProductService(IDbConnection _dbConnection) : IProductService
    {
        public async Task<int> AddProductAsync(Product product)
        {
            var query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            return await _dbConnection.ExecuteAsync(query, product);
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            var query = "DELETE FROM Product WHERE Id  = @Id";
            return await _dbConnection.ExecuteAsync(query, new {Id = productId});
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {

            var query = "SELECT * FROM Product";
            return await _dbConnection.QueryAsync<Product>(query);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var query = "SELECT * FROM Product WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Product>(query, new { Id = productId });
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var query = "Update Product SET Name = @Name, Price = @Price WHERE Id = @Id";
            return await  _dbConnection.ExecuteAsync(query, product);
        }
    }
}
