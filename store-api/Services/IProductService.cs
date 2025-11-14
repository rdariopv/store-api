using store_api.DTOs;
using xbiz_store.Models;

namespace store_api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<ProductDto?> GetByIdAsync(int id);
    }
}
