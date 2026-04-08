using Dapper;
using MyFirstApi.Data;
using MyFirstApi.Models;
using System.Data;

namespace MyFirstApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _context;
        private IDbConnection _connection;
        public ProductRepository(ApplicationDbContext appDbContext)
        {
            _connection = appDbContext.GetConnection();
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            string query = "insert into Products(ProductName, QuantityPerUnit, UnitPrice) values(@ProductName, @QuantityPerUnit, @UnitPrice)";
            int rowsAffected = await _connection.ExecuteAsync(query, product);
            return (rowsAffected > 0);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            string query = "DELETE FROM Products WHERE ProductID = @Id";
            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return (rowsAffected > 0);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            string query = "SELECT * FROM Products";
            return await _connection.QueryAsync<Product>(query);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            string query = "UPDATE Products SET ProductName = @ProductName, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice WHERE ProductID = @ProductID";
            int rowsAffected = await _connection.ExecuteAsync(query, new { ProductName = product.ProductName, QuantityPerUnit = product.QuantityPerUnit, UnitPrice = product.UnitPrice, ProductID = product.ProductID });
            return (rowsAffected > 0);
        }
    }
}
