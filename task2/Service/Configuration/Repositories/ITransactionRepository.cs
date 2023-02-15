using System.Threading.Tasks;
using Service.Models;

namespace Service.Configuration.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> Create(Transaction transaction);

        Task<Transaction> UpdateStatus(int transactionId, TransactionStatus status);
    }
}