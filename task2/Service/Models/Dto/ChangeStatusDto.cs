namespace Service.Models.Dto
{
    public class ChangeStatusDto
    {
        public int Id { get; set; }

        public TransactionStatus Status { get; set; }
    }
}