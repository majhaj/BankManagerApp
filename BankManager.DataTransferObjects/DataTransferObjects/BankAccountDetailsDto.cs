using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.DataTransferObjects
{
    public class BankAccountDetailsDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int BankId { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public int CurrencyId { get; set; }
        public string OwnerFormattedData { get; set; }


        //public string FirstApproverNumber { get; set; }
        //public string SecondApproverNumber { get; set; }
        //public string ThirdApproverNumber { get; set; }

    }
}
