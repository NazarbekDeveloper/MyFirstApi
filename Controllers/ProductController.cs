using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyFirstApi.Models;
using System.Data;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        //string connStr = @"Data Source=Nazarbek\MSSQLSERVER01;InitialCatalog=DatabaseNomi;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";
        public IDbConnection conn = new SqlConnection("Data Source=Nazarbek\\MSSQLSERVER01;Initial Catalog=NorthWindDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

        //Get All Products

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            string query = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products";
            IEnumerable<Product> products = await conn.QueryAsync<Product>(query);
            return products;
        }

        // Get Product By Id

        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            string query = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products WHERE ProductID = @Id";
            Product product = await conn.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
            return product;
        }

        // Add Product

        [HttpPost]
        public async Task<bool> AddProductBy(Product product)
        {
            string query = "insert into Products(ProductName, QuantityPerUnit, UnitPrice) values(@ProductName, @QuantityPerUnit, @UnitPrice)";

            int rowsAffected = await conn.ExecuteAsync(query, product);

            if (rowsAffected > 0) return true;
            else return false;
        }

        // Update Product

        [HttpPut("{id}")]
        public async Task<bool> UpdateProductById(int id, Product product)
        {
            string query = "update Products set ProductName = @ProductName, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice where ProductID = @ProductID";
            int rowsAffected  = await conn.ExecuteAsync(query, product);
            if(rowsAffected > 0) return true;
            else return false;
        }

    }
}