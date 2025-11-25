using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AvailableBalance { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OverdraftLimit { get; set; }

        [StringLength(3)]
        public string Currency { get; set; } = "USD";

        public AccountStatus Status { get; set; }

        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime? LastTransactionDate { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<CardTransaction>? CardTransactions { get; set; }
    }

    public enum AccountType
    {
        Checking,
        Savings,
        MoneyMarket,
        CD,
        Business
    }

    public enum AccountStatus
    {
        Active,
        Dormant,
        Frozen,
        Closed,
        UnderReview
    }
}
