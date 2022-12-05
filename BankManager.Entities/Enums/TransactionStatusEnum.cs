using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities.Enums
{
    public enum TransactionStatus
    {
        Draft = 10,
        Pending = 20,
        Rejected = 30,
        Accepted = 40
    }
}
