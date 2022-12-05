namespace BankManager.Api.Requests
{
    public class BankAccountRequest
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int BankId { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public int CurrencyId { get; set; }


        public int RequestorId { get; set; }
        public bool Blocked { get; set; }
    }
}
