using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    /// <summary>
    /// DTO con el detalle completo de una orden.
    /// Devuelto por GET /api/orders/{orderId}.
    /// Este mismo modelo se usa en shop_cart como OrderDetail.cs
    /// </summary>
    public class OrderDetailDto
    {
        public string OrderId { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string PaymentMethod { get; set; } = "";
        public string Status { get; set; } = "Confirmado";
        public CustomerInfo Customer { get; set; } = new();
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal Total { get; set; }
    }
}
