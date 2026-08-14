using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public class QrPaymentResult
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public string? OrderId { get; set; }

        public string? TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string? QrCode { get; set; }

        public DateTime? ExpiresAt { get; set; }
    }
}
