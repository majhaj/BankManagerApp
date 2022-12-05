using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Entities.SearchCriteriaModels
{
    public class AccountTransactionSearchCriteria : ISearchCriteria<AccountTransactionEntity>
    {
        public int? BankAccountId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? TransactionTypeId { get; set; }
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }


        public int? FromAccountId { get; set; }
        public int? ToAccountId { get; set; }


        public List<int> FromAccountOwnerIds { get; set; }
        public List<int> ToAccountOwnerIds { get; set; }


    }
}
