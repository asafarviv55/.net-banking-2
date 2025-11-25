using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentId { get; set; } = string.Empty;

        [Required]
        public int FromAccountId { get; set; }

        [ForeignKey("FromAccountId")]
        public virtual Account? FromAccount { get; set; }

        [StringLength(100)]
        public string? RecipientName { get; set; }

        [StringLength(20)]
        public string? RecipientAccountNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? ReferenceNumber { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        [StringLength(500)]
        public string? StatusMessage { get; set; }
    }

    public enum PaymentType
    {
        Transfer,
        BillPayment,
        Withdrawal,
        Deposit,
        WireTransfer,
        ACH
    }

    public enum PaymentMethod
    {
        Online,
        ATM,
        Branch,
        Mobile,
        Phone
    }

    public enum PaymentStatus
    {
        Initiated,
        Pending,
        Processing,
        Completed,
        Failed,
        Cancelled,
        Refunded
    }
}
