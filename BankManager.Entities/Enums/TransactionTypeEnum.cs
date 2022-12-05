using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities.Enums
{
    public enum TransactionTypeCode
    {
        CashTransfer = 10,
        Blik = 20,
        CashWithdrawalATM = 30,
        CashWithdrawalBranch = 40,
        CashDepositATM = 50,
        CashDepositBranch = 60,
        Repayment = 70
    }

}
