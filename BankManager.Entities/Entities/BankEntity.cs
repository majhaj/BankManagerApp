using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class BankEntity : Entity
    {
        public string Name { get; set; }
        public string Bic { get; set; }

        public virtual ICollection<BankAccountEntity> BankAccounts { get; set; }

        public override string GetCreationProcessDescription()
        {
            var result = $"Created Bank name {Name} ";

            return result;
        }
    }
}
