namespace BankManager.DataTransferObjects
{
    public class AccountTransactionDto
    {
        public int Id { get; set; }
        public int TransactionType { get; set; }
        public int Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }

        public int? PendingApprovmentId { get; set; }


        public IEnumerable<ApprovementDto> Approvements { get; set;}
    }
}
