
using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Entities.Interfaces;
using BankManager.Services.Interfaces;

namespace BankManager.Services
{

    public class AsianTaxService : ITaxService
    {
        public IBankManagerContext BankManagerContext { get; }

        public AsianTaxService(IBankManagerContext bankManagerContext)
        {
            BankManagerContext = bankManagerContext;
        }

        public int CountryId { get; set; }

        public double ApplyBenefit(ICompany company)
        {

            var banks = BankManagerContext.Banks.ToList();


            return 1;
        }

        public double ApplySpecialCompanyTax(ICompany company)
        {
            return 0;
        }

        public double CalculateTotalTax(ICompany company)
        {
            var citTax = company.GetCit(CountryId);
            var vatTax = company.GetDomesticVat(CountryId);

            var result = (citTax + vatTax) * 0.98;

            return result;
        }

        public void PrepareInitialData(ICompany company)
        {

        }
    }
}
