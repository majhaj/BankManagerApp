using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities
{
    public class NotificationEntity : Entity
    {
        public bool NotifiedByApp { get; set; }
        public bool NotifiedByService { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int UserToNotifyId { get; set; }
        public UserEntity Creator { get; set; }
    }
}
