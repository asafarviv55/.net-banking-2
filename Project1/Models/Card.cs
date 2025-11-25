using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        [Required]
        [StringLength(100)]
        public string CardHolderName { get; set; } = string.Empty;

        public CardType CardType { get; set; }

        public CardBrand Brand { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [StringLength(3)]
        public string CVV { get; set; } = string.Empty;

        [StringLength(4)]
        public string PIN { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CreditLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DailyLimit { get; set; }

        public CardStatus Status { get; set; }

        public bool IsContactless { get; set; }
        public bool IsVirtual { get; set; }

        public DateTime? ActivatedDate { get; set; }
        public DateTime? LastUsedDate { get; set; }

        public virtual ICollection<CardTransaction>? Transactions { get; set; }
    }

    public enum CardType
    {
        Debit,
        Credit,
        Prepaid,
        Virtual
    }

    public enum CardBrand
    {
        Visa,
        MasterCard,
        AmericanExpress,
        Discover,
        UnionPay
    }

    public enum CardStatus
    {
        Inactive,
        Active,
        Blocked,
        Expired,
        Lost,
        Stolen,
        Cancelled
    }
}
