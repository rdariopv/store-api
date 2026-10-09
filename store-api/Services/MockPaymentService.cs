using xbiz_store.DTOs;

namespace store_api.Services
{
    public class MockPaymentService : IPaymentService
    {
        public Task<PaymentStatusResult> CheckPaymentAsync(string transactionId)
        {
            var result = new PaymentStatusResult
            {
                Success = true,
                Paid = false,
                Status = "PENDING",
                TransactionId = transactionId
            };

            return Task.FromResult(result);
        }

        public Task<QrPaymentResult> CreateQrPaymentAsync(string orderId, decimal amount)
        {
            var transactionId =
             $"TX-{Guid.NewGuid():N}".ToUpper();

            var qrContent =
                $"SHOPCART|{orderId}|{transactionId}|{amount:0.00}";

            var result = new QrPaymentResult
            {
                Success = true,
                Message = "QR generado correctamente",
                OrderId = orderId,
                TransactionId = transactionId,
                Amount = amount,
                QrCode = qrContent,
                ExpiresAt = DateTime.Now.AddMinutes(5)
            };

            return Task.FromResult(result);
        }
    }
}
