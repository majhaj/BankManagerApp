using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class EntityDeletable : Entity
    {
        public DateTime? DeletionDate { get; set; }
       
        
        
        public bool IsActive => DeletionDate.HasValue;

        public virtual string GetDeletionProcessDescription()
        {
            var result = "";


            return result;
        }
    }
}
