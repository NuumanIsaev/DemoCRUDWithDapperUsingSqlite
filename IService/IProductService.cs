using DemoCRUDwithDapperUsingSqlite.Models;

namespace DemoCRUDwithDapperUsingSqlite.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
    }
}
