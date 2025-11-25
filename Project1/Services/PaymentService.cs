using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPaymentAsync(Payment payment);
        Task<List<Payment>> GetAccountPaymentsAsync(int accountId);
        Task<Payment?> GetPaymentByIdAsync(string paymentId);
        Task<bool> CancelPaymentAsync(int id);
    }

    public class PaymentService : IPaymentService
    {
        private readonly BankingContext _context;

        public PaymentService(BankingContext context)
        {
            _context = context;
        }

        public async Task<Payment> ProcessPaymentAsync(Payment payment)
        {
            payment.PaymentId = GeneratePaymentId();
            payment.CreatedDate = DateTime.UtcNow;
            payment.Status = PaymentStatus.Pending;

            var account = await _context.Accounts.FindAsync(payment.FromAccountId);
            if (account == null)
            {
                payment.Status = PaymentStatus.Failed;
                payment.StatusMessage = "Account not found";
            }
            else if (account.AvailableBalance < payment.Amount)
            {
                payment.Status = PaymentStatus.Failed;
                payment.StatusMessage = "Insufficient funds";
            }
            else
            {
                account.Balance -= payment.Amount;
                account.AvailableBalance -= payment.Amount;
                account.LastTransactionDate = DateTime.UtcNow;

                payment.Status = PaymentStatus.Completed;
                payment.ProcessedDate = DateTime.UtcNow;
                payment.CompletedDate = DateTime.UtcNow;
                payment.StatusMessage = "Payment completed successfully";
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<List<Payment>> GetAccountPaymentsAsync(int accountId)
        {
            return await _context.Payments
                .Where(p => p.FromAccountId == accountId)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(string paymentId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        public async Task<bool> CancelPaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null || payment.Status != PaymentStatus.Pending)
                return false;

            payment.Status = PaymentStatus.Cancelled;
            payment.StatusMessage = "Payment cancelled by user";

            await _context.SaveChangesAsync();
            return true;
        }

        private string GeneratePaymentId()
        {
            return $"PAY{DateTime.UtcNow.Ticks}";
        }
    }
}
