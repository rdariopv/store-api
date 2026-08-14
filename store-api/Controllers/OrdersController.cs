using Microsoft.AspNetCore.Mvc;
using store_api.Services;
using xbiz_store.DTOs;

namespace store_api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// POST /api/orders
        /// Recibe el carrito y crea una nueva orden.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
                return BadRequest(new OrderResponse
                {
                    Success = false,
                    Message = "El carrito está vacío."
                });

            if (string.IsNullOrWhiteSpace(request.Customer.FirstName) ||
                string.IsNullOrWhiteSpace(request.Customer.Email))
                return BadRequest(new OrderResponse
                {
                    Success = false,
                    Message = "Datos del cliente incompletos."
                });

            var result = await _orderService.CreateOrderAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// GET /api/orders/{orderId}
        /// Devuelve el detalle completo de una orden para mostrar en el comprobante.
        /// </summary>
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return BadRequest(new { message = "El ID de la orden es requerido." });

            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order == null)
                return NotFound(new { message = $"No se encontró la orden con ID '{orderId}'." });

            return Ok(order);
        }
    }
}
