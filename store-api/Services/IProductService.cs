using xbiz_store.DTOs;

namespace store_api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<ProductDto?> GetByIdAsync(int id);
        Task<byte[]?> GetImageByIdAsync(int id);

        Task<List<int>> GetListImagesbyIdProductAsync(int id);
    }
}
