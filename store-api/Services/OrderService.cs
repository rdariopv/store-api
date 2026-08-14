using xbiz_store.DTOs;
using xbiz_store.Repository;

namespace store_api.Services
{
    /// <summary>
    /// Servicio de órdenes.
    /// Sigue el mismo patrón que ProductService:
    /// orquesta el repositorio y aplica lógica de negocio.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepo = orderRepository;
            _logger = logger;
        }

        /// <summary>
        /// Valida, procesa y guarda una nueva orden.
        /// </summary>
        public async Task<OrderResponse> CreateOrderAsync(OrderRequest request)
        {
            // Recalcular total en el servidor — nunca confiar en el total del cliente
            var total = request.Items.Sum(i => i.Price * i.Quantity);

            _logger.LogInformation(
                "Procesando orden: {Email} | {Count} items | ${Total} | {Method}",
                request.Customer.Email,
                request.Items.Count,
                total,
                request.PaymentMethod);

            // Guardar en BD a través del repositorio
            var orderId = await _orderRepo.SaveAsync(request);

            _logger.LogInformation("Orden creada con ID: {OrderId}", orderId);

            return new OrderResponse
            {
                Success = true,
                OrderId = orderId,
                Message = "Orden creada exitosamente.",
                Total = total
            };
        }

        /// <summary>
        /// Obtiene el detalle completo de una orden para el comprobante.
        /// </summary>
        public async Task<OrderDetailDto?> GetOrderByIdAsync(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return null;

            return await _orderRepo.GetByIdAsync(orderId);
        }
    }
}
