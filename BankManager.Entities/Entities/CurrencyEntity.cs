using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class CurrencyEntity : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastModified { get; set; }



        public ICollection<BankAccountEntity> BankAccounts { get; set; }


        public override string GetCreationProcessDescription()
        {
            var result = $"Created Currency name {Name} ";

            return result;
        }
    }
}
