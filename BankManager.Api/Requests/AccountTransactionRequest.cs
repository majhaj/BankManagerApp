namespace BankManager.Api.Requests
{
    public class AccountTransactionRequest
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public int ToAccountId { get; set; }
        public int Amount { get; set; }

        public int CreatorId { get; set; }
    }
}
