using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class CardTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionId { get; set; } = string.Empty;

        [Required]
        public int CardId { get; set; }

        [ForeignKey("CardId")]
        public virtual Card? Card { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(200)]
        public string MerchantName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? MerchantCategory { get; set; }

        [StringLength(200)]
        public string? Location { get; set; }

        public TransactionType TransactionType { get; set; }

        public TransactionStatus Status { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime PostedDate { get; set; }

        [StringLength(50)]
        public string? AuthorizationCode { get; set; }

        public bool IsInternational { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ExchangeRate { get; set; }

        [StringLength(3)]
        public string? OriginalCurrency { get; set; }
    }

    public enum TransactionType
    {
        Purchase,
        Refund,
        ATMWithdrawal,
        CashAdvance,
        BalanceInquiry,
        Payment
    }

    public enum TransactionStatus
    {
        Pending,
        Authorized,
        Posted,
        Declined,
        Reversed
    }
}
