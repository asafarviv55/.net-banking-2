using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class DirectDeposit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployerName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? EmployerRoutingNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ExpectedAmount { get; set; }

        public DepositFrequency Frequency { get; set; }

        public DateTime? NextExpectedDate { get; set; }
        public DateTime? LastDepositDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LastDepositAmount { get; set; }

        public DirectDepositStatus Status { get; set; }

        public DateTime SetupDate { get; set; }
        public DateTime? EffectiveDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal AllocationPercentage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AllocationAmount { get; set; }

        public AllocationType AllocationType { get; set; }

        public bool IsPrimary { get; set; }
    }

    public enum DepositFrequency
    {
        Weekly,
        BiWeekly,
        SemiMonthly,
        Monthly,
        Irregular
    }

    public enum DirectDepositStatus
    {
        Pending,
        Active,
        Paused,
        Cancelled
    }

    public enum AllocationType
    {
        Percentage,
        FixedAmount,
        Remainder
    }
}
