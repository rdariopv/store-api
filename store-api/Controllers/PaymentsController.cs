using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_api.Services;
using xbiz_store.DTOs;

namespace store_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("qr")]
        public async Task<IActionResult> CreateQrPayment(
       [FromBody] CreateQrPaymentRequest request)
        {
            var result = await _paymentService.CreateQrPaymentAsync(
                request.OrderId,
                request.Amount);

            return Ok(result);
        }

        [HttpGet("qr/{transactionId}/status")]
        public async Task<IActionResult> CheckPayment(
        string transactionId)
        {
            var result =
                await _paymentService.CheckPaymentAsync(transactionId);

            return Ok(result);
        }
    }
}
