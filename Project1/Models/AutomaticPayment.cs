using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class AutomaticPayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        [Required]
        [StringLength(100)]
        public string PayeeName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? PayeeAccountNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }

        public bool IsVariableAmount { get; set; }

        public PaymentFrequency Frequency { get; set; }

        public int DayOfMonth { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        public AutoPaymentStatus Status { get; set; }

        [StringLength(200)]
        public string? Memo { get; set; }

        public int PaymentsCompleted { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPaid { get; set; }

        public bool SendNotification { get; set; }

        [StringLength(150)]
        public string? NotificationEmail { get; set; }

        public PaymentCategory Category { get; set; }
    }

    public enum PaymentFrequency
    {
        Weekly,
        BiWeekly,
        Monthly,
        Quarterly,
        SemiAnnually,
        Annually
    }

    public enum AutoPaymentStatus
    {
        Active,
        Paused,
        Suspended,
        Cancelled,
        Completed
    }

    public enum PaymentCategory
    {
        Utilities,
        Mortgage,
        Rent,
        Insurance,
        Loan,
        CreditCard,
        Subscription,
        Other
    }
}
