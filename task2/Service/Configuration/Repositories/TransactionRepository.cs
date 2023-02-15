using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Models;

namespace Service.Configuration.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        readonly object _locker = new();
        readonly DbContextOptions<BankingContext> _contextOptions;
        readonly IServiceScopeFactory _scopeFactory;

        public TransactionRepository(
            DbContextOptions<BankingContext> contextOptions,
            IServiceScopeFactory scopeFactory)
        {
            _contextOptions = contextOptions;
            _scopeFactory = scopeFactory;
        }

        /// <summary>
        /// Create new transaction.
        /// </summary>
        /// <param name="transactionNew"></param>
        /// <returns></returns>
        public async Task<Transaction> Create(Transaction transactionNew)
        {
            var newContext = new BankingContext(_contextOptions);
            if (transactionNew.Status == TransactionStatus.Pending)
            {
                var transaction = ChangeAccountBalance(transactionNew);
                var res = await newContext.Transactions.AddAsync(transaction);
                await newContext.SaveChangesAsync();
                return res.Entity;
            }
            else
            {
                var res = await newContext.Transactions.AddAsync(transactionNew);
                await newContext.SaveChangesAsync();
                return res.Entity;
            }
        }

        /// <summary>
        /// Update transaction status.
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<Transaction> UpdateStatus(int transactionId, TransactionStatus status)
        {
            var newContext = new BankingContext(_contextOptions);
            if (status == TransactionStatus.Pending)
            {
                var transactionDb = await newContext.Transactions.FindAsync(transactionId);
                var transaction = ChangeAccountBalance(transactionDb);
                var res = newContext.Transactions.Update(transaction);
                await newContext.SaveChangesAsync();
                return res.Entity;
            }
            else
            {
                var transactionDb = await newContext.Transactions.FindAsync(transactionId);
                transactionDb.Status = status;
                var res = newContext.Transactions.Update(transactionDb);
                await newContext.SaveChangesAsync();
                return res.Entity;
            }
        }

        Transaction ChangeAccountBalance(Transaction transaction)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var scopedContext = scope.ServiceProvider.GetRequiredService<BankingContext>();
                lock (_locker)
                {
                    var account = scopedContext.Accounts.Find(transaction.AccountId);
                    var amount = transaction.Direction switch
                    {
                        TransactionDirection.Income => account.Balance + transaction.Amount,
                        TransactionDirection.Outcome => account.Balance - transaction.Amount
                    };

                    if (amount >= 0)
                    {
                        account.Balance = amount;
                        scopedContext.Accounts.Update(account);
                        transaction.Status = TransactionStatus.Completed;
                    }
                    else
                    {
                        transaction.Status = TransactionStatus.Declined;
                    }

                    scopedContext.SaveChanges();
                    return transaction;
                }
            }
        }
    }
}