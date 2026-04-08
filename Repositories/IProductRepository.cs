using MyFirstApi.Models;

namespace MyFirstApi.Repositories
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
