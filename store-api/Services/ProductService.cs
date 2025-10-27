using xbiz_store.Models;
using xbiz_store.Repository;

namespace store_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;
        public ProductService(IProductRepository productRepository)
        {
            productRepo = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Aquí podrías aplicar lógica adicional, por ejemplo:
            // - Filtrar productos activos
            // - Ordenar por precio, nombre, o stock
            return await productRepo.GetAllAsync();
        }

        // Retorna un producto por ID
        public async Task<Product?> GetByIdAsync(int id)
        {
            // Aquí podrías agregar validaciones de negocio:
            // - Validar si el producto está activo
            // - Incluir control de errores o logging
            return await productRepo.GetByIdAsync(id);
        }
    }
}
