namespace Service.Models.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public TransactionDirection Direction { get; set; }

        public TransactionType Type { get; set; }

        public TransactionStatus Status { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public int AccountId { get; set; }
    }
}