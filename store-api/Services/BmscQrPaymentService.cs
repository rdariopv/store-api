using xbiz_store.DTOs;

namespace store_api.Services
{
    public class BmscQrPaymentService : IPaymentService
    {
        public Task<PaymentStatusResult> CheckPaymentAsync(string transactionId)
        {
            throw new NotImplementedException();

        }

        public Task<QrPaymentResult> CreateQrPaymentAsync(string orderId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
