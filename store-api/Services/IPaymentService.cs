using xbiz_store.DTOs;

namespace store_api.Services
{
    public interface IPaymentService
    {
        Task<QrPaymentResult> CreateQrPaymentAsync(string orderId,decimal amount);

        Task<PaymentStatusResult> CheckPaymentAsync(
            string transactionId);
    }
}
