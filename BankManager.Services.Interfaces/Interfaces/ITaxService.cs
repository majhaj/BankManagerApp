using BankManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Interfaces
{
    public interface ITaxService
    {
        int CountryId { get; set; }
        double CalculateTotalTax(ICompany company);
        void PrepareInitialData(ICompany company);

        double ApplyBenefit(ICompany company);
        double ApplySpecialCompanyTax(ICompany company);
    }
}
