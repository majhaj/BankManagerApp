using BankManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class ApprovementTypeEntity : Entity
    {
        public string Name { get; set; }
        public ApprovementTypeCode Code { get; set; }
        public int CreatorId { get; set; }

        public virtual UserEntity Creator { get; set; }
        public virtual ICollection<ApprovementEntity> Approvements { get; set; }

        public override string GetCreationProcessDescription()
        {
            var result = $"Created Approvment type name {Name} ";

            return result;
        }
    }
}
