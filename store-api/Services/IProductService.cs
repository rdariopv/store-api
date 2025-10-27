using xbiz_store.Models;

namespace store_api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetByIdAsync(int id);
    }
}
