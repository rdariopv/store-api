using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public  class OrderRequest
    {
        public CustomerInfo Customer { get; set; } = new();
        public string PaymentMethod { get; set; } = "card";
        public CardInfo? Card { get; set; }
        public string? CashNote { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal Total { get; set; }
    }
}
