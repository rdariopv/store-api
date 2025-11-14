using AutoMapper;
using store_api.DTOs;
using xbiz_store.Models;
using xbiz_store.Repository;

namespace store_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository,IMapper arg_mapper)
        {
            this.productRepo = productRepository;
            this.mapper = arg_mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            // Aquí podrías aplicar lógica adicional, por ejemplo:
            // - Filtrar productos activos
            // - Ordenar por precio, nombre, o stock
            var products = await productRepo.GetAllAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        // Retorna un producto por ID
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            // Aquí podrías agregar validaciones de negocio:
            // - Validar si el producto está activo
            // - Incluir control de errores o logging

            var product = await productRepo.GetByIdAsync(id);
            if (product == null) { 
                return null;
            }
            return mapper.Map<ProductDto>(product);
        }
    }
}
