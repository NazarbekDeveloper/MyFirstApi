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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result =  await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        // Get Product By Id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result =  await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        // Add Product

        [HttpPost]
        public async Task<ActionResult<bool>> AddProductBy(Product product)
        {
            var result =  await _productService.CreateProductAsync(product);
            return (result)? Ok(result) : BadRequest("Product qo'shishda xatolik yuz berdi");
        }

        // Update Product

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateProductById(int id, Product product)
        {
            var result =  await _productService.UpdateProductAsync(product);
            return (result) ? Ok(result) : BadRequest("Product yangilashda xatolik yuz berdi");
        }
        // Delete Product
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductById(int id)
        {
            var result =  await _productService.DeleteProductAsync(id);
            return (result) ? Ok(result) : BadRequest("Product o'chirishda xatolik yuz berdi");
        }
    }
}