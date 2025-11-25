using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class LoanApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string ApplicationNumber { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        public LoanType LoanType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RequestedAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ApprovedAmount { get; set; }

        public int RequestedTermMonths { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? ProposedInterestRate { get; set; }

        [StringLength(200)]
        public string Purpose { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AnnualIncome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyDebts { get; set; }

        [StringLength(100)]
        public string EmploymentStatus { get; set; } = string.Empty;

        [StringLength(200)]
        public string? EmployerName { get; set; }

        public int? CreditScore { get; set; }

        public ApplicationStatus Status { get; set; }

        public DateTime ApplicationDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? ApprovalDate { get; set; }

        [StringLength(500)]
        public string? ReviewNotes { get; set; }

        [StringLength(100)]
        public string? ReviewedBy { get; set; }

        public bool RequiresCollateral { get; set; }

        [StringLength(200)]
        public string? CollateralDescription { get; set; }
    }

    public enum LoanType
    {
        Personal,
        Auto,
        Home,
        Business,
        Student,
        Consolidation
    }

    public enum ApplicationStatus
    {
        Draft,
        Submitted,
        UnderReview,
        RequiresDocuments,
        Approved,
        Rejected,
        Cancelled,
        Disbursed
    }
}
