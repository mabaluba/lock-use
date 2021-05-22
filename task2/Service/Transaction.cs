using System.ComponentModel.DataAnnotations.Schema;

namespace Service
{
    [Table("transactions")]
    public class Transaction
    {
        [Column("id")]
        public int Id { get; set; }
    
        [Column("direction")]
        public TransactionDirection Direction { get; set; }
    
        [Column("type")]
        public TransactionType Type { get; set; }
    
        [Column("status")]
        public TransactionStatus Status { get; set; }
    
        [Column("currency")]
        public string Currency { get; set; }
    
        [Column("amount")]
        public decimal Amount { get; set; }
    
        [Column("account_id")]
        public int AccountId { get; set; }
    }
}