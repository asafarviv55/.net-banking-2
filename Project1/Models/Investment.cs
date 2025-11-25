using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string InvestmentId { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [Required]
        [StringLength(100)]
        public string InvestmentName { get; set; } = string.Empty;

        public InvestmentType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal InitialInvestment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalGainLoss { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal ReturnPercentage { get; set; }

        [StringLength(20)]
        public string? TickerSymbol { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PricePerShare { get; set; }

        public RiskLevel RiskLevel { get; set; }

        public InvestmentStatus Status { get; set; }

        public DateTime PurchaseDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public bool AutoReinvest { get; set; }
    }

    public enum InvestmentType
    {
        Stock,
        Bond,
        MutualFund,
        ETF,
        CD,
        MoneyMarket,
        RealEstate,
        Cryptocurrency
    }

    public enum RiskLevel
    {
        VeryLow,
        Low,
        Moderate,
        High,
        VeryHigh
    }

    public enum InvestmentStatus
    {
        Active,
        Pending,
        Matured,
        Sold,
        Suspended
    }
}
