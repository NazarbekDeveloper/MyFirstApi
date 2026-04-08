using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyFirstApi.Models;
using MyFirstApi.Services;
using System.Data;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //Get All Products

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productService.GetAllProductsAsync();
        }

        // Get Product By Id

        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        // Add Product

        [HttpPost]
        public async Task<bool> AddProductBy(Product product)
        {
            return await _productService.CreateProductAsync(product);
        }

        // Update Product

        [HttpPut("{id}")]
        public async Task<bool> UpdateProductById(int id, Product product)
        {
            return await _productService.UpdateProductAsync(product);
        }
        // Delete Product
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProductById(int id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}