using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class LoanApplicationEntity : Entity
    {
        public override string GetCreationProcessDescription()
        {
            var result = $"Created Loan Application name";

            return result;
        }
    }
}
