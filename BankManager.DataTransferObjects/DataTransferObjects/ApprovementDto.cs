using BankManager.Entities;
using BankManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.DataTransferObjects
{
    public class ApprovementDto
    {
        public int ApproverId { get; set; }
        public DateTime? ActionDate { get; set; }
        public ApprovementStatus Status { get; set; }
        public UserDto Approver { get; set; }
    }
}
