using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public  class OrderResponse
    {
        public bool Success { get; set; }
        public string OrderId { get; set; } = "";
        public string Message { get; set; } = "";
        public decimal Total { get; set; }
    }
}
