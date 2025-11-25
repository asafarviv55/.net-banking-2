using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardTransaction> CardTransactions { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<DirectDeposit> DirectDeposits { get; set; }
        public DbSet<AutomaticPayment> AutomaticPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.SSN)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.PaymentId)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.CardNumber)
                .IsUnique();

            modelBuilder.Entity<CardTransaction>()
                .HasIndex(ct => ct.TransactionId)
                .IsUnique();

            modelBuilder.Entity<Mortgage>()
                .HasIndex(m => m.MortgageNumber)
                .IsUnique();

            modelBuilder.Entity<Investment>()
                .HasIndex(i => i.InvestmentId)
                .IsUnique();

            modelBuilder.Entity<LoanApplication>()
                .HasIndex(l => l.ApplicationNumber)
                .IsUnique();

            modelBuilder.Entity<DirectDeposit>()
                .HasOne(dd => dd.Account)
                .WithMany()
                .HasForeignKey(dd => dd.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AutomaticPayment>()
                .HasOne(ap => ap.Account)
                .WithMany()
                .HasForeignKey(ap => ap.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
