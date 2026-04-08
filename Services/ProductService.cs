using MyFirstApi.Models;
using MyFirstApi.Repositories;

namespace MyFirstApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> CreateProductAsync(Product product)
        {
            if(product == null) throw new NullReferenceException("Product null bo'lishi mumkun emas");
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if(id <= 0) throw new ArgumentException("Id 0 va undan kichik bo'lishi mumkun emas");
            return await _productRepository.DeleteProductAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidDataException("Id 0 va undan kichik bo'lishi mumkun emas");
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if (product == null) throw new NullReferenceException("yangilanayotgan product null bo'lishi mumkin emas");
            return await _productRepository.UpdateProductAsync(product);
        }
    }
}
