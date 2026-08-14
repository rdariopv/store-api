using xbiz_store.DTOs;

namespace store_api.Services
{
    /// <summary>
    /// Interfaz del servicio de órdenes.
    /// Sigue el mismo patrón que IProductService.
    /// </summary>
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest request);
        Task<OrderDetailDto?> GetOrderByIdAsync(string orderId);
    }
}
