using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public class PaymentStatusResult
    {
        public bool Success { get; set; }

        public bool Paid { get; set; }

        public string? Status { get; set; }

        public string? Message { get; set; }

        public string? TransactionId { get; set; }

        public string? OrderId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PaidAt { get; set; }
    }
}
