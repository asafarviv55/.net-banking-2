using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> ProcessPayment(Payment payment)
        {
            var result = await _paymentService.ProcessPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = result.PaymentId }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(string id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAccountPayments(int accountId)
        {
            var payments = await _paymentService.GetAccountPaymentsAsync(accountId);
            return Ok(payments);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelPayment(int id)
        {
            var result = await _paymentService.CancelPaymentAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
