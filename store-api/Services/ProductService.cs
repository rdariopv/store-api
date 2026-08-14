using xbiz_store.DTOs;
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
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            // Aquí podrías aplicar lógica adicional, por ejemplo:
            // - Filtrar productos activos
            // - Ordenar por precio, nombre, o stock

            var products=  await productRepo.GetAllAsync();
            var productos = products.Select(p => new ProductDto
            {
                Id = Convert.ToString( p.Codigo),
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.PrecioVenta,
                Imagen = p.Imagen != null
        ? "data:image/png;base64," + Convert.ToBase64String(p.Imagen)
        : null
            });

            return productos;
        }

        // Retorna un producto por ID
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            // Aquí podrías agregar validaciones de negocio:
            // - Validar si el producto está activo
            // - Incluir control de errores o logging

            var objproductQuery = await productRepo.GetByIdAsync(id);
            var productos =  new ProductDto
            {
                Id =Convert.ToString( objproductQuery.Codigo),
                Nombre = objproductQuery.Nombre,
                Descripcion = objproductQuery.Descripcion,
                Precio = objproductQuery.PrecioVenta,
                Imagen = objproductQuery.Imagen != null ?  Convert.ToBase64String(objproductQuery.Imagen) : null
                // Imagen = objproductQuery.Imagen != null ? "data:image/png;base64," + Convert.ToBase64String(objproductQuery.Imagen) : null
            };

            return productos;
        }

        // Retorna un producto por ID
        public async Task<byte[]?> GetImageByIdAsync(int id)
        {
            // Aquí podrías agregar validaciones de negocio:
            // - Validar si el producto está activo
            // - Incluir control de errores o logging

            var objproductQuery = await productRepo.GetByIdAsync(id);
            if (objproductQuery == null) {
                return null;
            }
            return objproductQuery.Imagen;
        }

        public async Task<List<int>> GetListImagesbyIdProductAsync(int id)
        {
            List<int> listId =  new List<int>();
            listId.Add(id);
            listId.Add(4);
            listId.Add(5);
            return await Task.FromResult( listId);
            //throw new NotImplementedException();
        }

        public async Task<ProductFilterResult> SearchProductsAsync(ProductFilterRequest filters)
        {
            var (items, total) = await productRepo.SearchAsync(filters);

            return new ProductFilterResult
            {
                Items = items.Select(p => new ProductDto
                {
                    Id = Convert.ToString(p.Codigo),
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.PrecioVenta,
                    Imagen = p.Imagen != null
                        ? "data:image/png;base64," + Convert.ToBase64String(p.Imagen)
                        : null
                }),
                TotalItems = total,
                Page = filters.Page,
                PageSize = filters.PageSize
            };
        }

        public async Task<IEnumerable<string>> GetCategoriasAsync()
            => await productRepo.GetCategoriasAsync();

        public async Task<IEnumerable<string>> GetMarcasAsync()
            => await productRepo.GetMarcasAsync();

    }
}
