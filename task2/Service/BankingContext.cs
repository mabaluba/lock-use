using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Service
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {

        }
        
        static BankingContext()
        {
            NpgsqlConnection.GlobalTypeMapper
                .MapEnum<TransactionType>()
                .MapEnum<TransactionDirection>()
                .MapEnum<TransactionStatus>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
            modelBuilder.HasPostgresEnum<TransactionType>();
            modelBuilder.HasPostgresEnum<TransactionDirection>();
            modelBuilder.HasPostgresEnum<TransactionStatus>();

            modelBuilder.Entity<Account>().HasData(new List<Account>
            {
                new() {Id = 1, Name = "Main Fund", Balance = 25000, Currency = "GBP"},
                new() {Id = 2, Name = "For investment", Balance = 1000, Currency = "GBP"},
                new() {Id = 3, Name = "For Canada market", Balance = 150, Currency = "CAN"},
                new() {Id = 4, Name = "For USA market", Balance = 50, Currency = "USD"},
            });
  
    
            modelBuilder.Entity<Transaction>().HasData(new List<Transaction>
            {
                new()
                {
                    Id = 1, Status = TransactionStatus.Completed, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Outcome, Currency = "USD", Amount = 500, AccountId = 4
                },                
                new()
                {
                    Id = 2, Status = TransactionStatus.Pending, Type = TransactionType.FX,
                    Direction = TransactionDirection.Income, Currency = "USD", Amount = 16.49m, AccountId = 4
                },
                new()
                {
                    Id = 3, Status = TransactionStatus.Pending, Type = TransactionType.Fee,
                    Direction = TransactionDirection.Income, Currency = "USD", Amount = 0.05m, AccountId = 4
                },               
                new()
                {
                    Id = 4, Status = TransactionStatus.Pending, Type = TransactionType.Fee,
                    Direction = TransactionDirection.Outcome, Currency = "CAN", Amount = 0.25m, AccountId = 3
                },                
                new()
                {
                    Id = 5, Status = TransactionStatus.Pending, Type = TransactionType.FX,
                    Direction = TransactionDirection.Outcome, Currency = "CAN", Amount = 20.0m, AccountId = 3
                },
                new()
                {
                    Id = 6, Status = TransactionStatus.Declined, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Income, Currency = "USD", Amount = 1000.0m, AccountId = 3
                },                
                new()
                {
                    Id = 7, Status = TransactionStatus.Pending, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Income, Currency = "GBP", Amount = 50.0m, AccountId = 1
                },        
                new()
                {
                    Id = 8, Status = TransactionStatus.Declined, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 12.52m, AccountId = 1
                },                
                new()
                {
                    Id = 9, Status = TransactionStatus.Declined, Type = TransactionType.Fee,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 0.15m, AccountId = 1
                },                
                new()
                {
                    Id = 10, Status = TransactionStatus.Pending, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 12000.81m, AccountId = 1
                },                
                new() {
                    Id = 11, Status = TransactionStatus.Declined, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Income, Currency = "GBP", Amount = 20.0m, AccountId = 2
                },
                new() {
                    Id = 12, Status = TransactionStatus.Declined, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 100.0m, AccountId = 2
                },
                new() {
                    Id = 13, Status = TransactionStatus.Completed, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 5.0m, AccountId = 2
                },
                new() {
                    Id = 14, Status = TransactionStatus.Completed, Type = TransactionType.Transfer,
                    Direction = TransactionDirection.Income, Currency = "GBP", Amount = 5.0m, AccountId = 2
                },
                new() {
                    Id = 15, Status = TransactionStatus.Completed, Type = TransactionType.Fee,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 200.0m, AccountId = 2
                },
                new() {
                    Id = 16, Status = TransactionStatus.Pending, Type = TransactionType.Fee,
                    Direction = TransactionDirection.Outcome, Currency = "GBP", Amount = 0.25m, AccountId = 2
                },
               
            });
        }
    }
}