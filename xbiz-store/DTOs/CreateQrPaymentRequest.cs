using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public class CreateQrPaymentRequest
    {
        public string OrderId { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
