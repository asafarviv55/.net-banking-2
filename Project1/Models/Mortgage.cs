using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Mortgage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string MortgageNumber { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PropertyValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DownPayment { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; }

        public int TermYears { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyPayment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OutstandingBalance { get; set; }

        [StringLength(200)]
        public string PropertyAddress { get; set; } = string.Empty;

        public MortgageType MortgageType { get; set; }

        public MortgageStatus Status { get; set; }

        public DateTime OriginationDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime? NextPaymentDue { get; set; }

        public int PaymentsMade { get; set; }
        public int TotalPayments { get; set; }

        public bool IsEscrowSetup { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? EscrowBalance { get; set; }
    }

    public enum MortgageType
    {
        Conventional,
        FHA,
        VA,
        USDA,
        Jumbo,
        FixedRate,
        ARM
    }

    public enum MortgageStatus
    {
        Application,
        Underwriting,
        Approved,
        Active,
        Delinquent,
        Foreclosure,
        PaidOff
    }
}
