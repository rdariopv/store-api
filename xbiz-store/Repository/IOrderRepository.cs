using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.DTOs;

namespace xbiz_store.Repository
{
    /// <summary>
    /// Interfaz del repositorio de órdenes.
    /// Sigue el mismo patrón que IProductRepository.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Guarda una nueva orden en la BD y devuelve el ID generado.
        /// </summary>
        Task<string> SaveAsync(OrderRequest request);

        /// <summary>
        /// Obtiene el detalle completo de una orden por su ID.
        /// </summary>
        Task<OrderDetailDto?> GetByIdAsync(string orderId);
    }
}
