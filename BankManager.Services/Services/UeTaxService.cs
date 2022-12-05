using BankManager.DataAccess;
using BankManager.Entities.Interfaces;
using BankManager.Services.Interfaces;
using BankManager.Services.Interfaces.Interfaces;

namespace BankManager.Services
{
    public class UeTaxService : ITaxService
    {
        public IBankManagerContext Context { get; }
        public IBankAccountService BankAccountService { get; }

        public UeTaxService(IBankManagerContext context, 
            IBankAccountService bankAccountService)
        {
            Context = context;
            BankAccountService = bankAccountService;
        }

        public int CountryId { get; set; }
        public double AdditionalUeTax { get; set; }

        public double ApplyBenefit(ICompany company)
        {
           var bank = Context.Banks.FirstOrDefault(x => x.Name == "ING");

            double result = 1;

            var totalTax = CalculateTotalTax(company);

            if (totalTax < 1000000)
            {
                result = 0.95;
            }
            else if (totalTax >= 10000000 && totalTax <= 10000000)
            {
                result = 0.93;
            }
            else
            {
                result = 0.90;
            }

            return result;
        }

        public double ApplySpecialCompanyTax(ICompany company)
        {
            if (company.Income < 1000000)
            {
                return 10000;
            }
            else
            {
                return 30000;
            }
        }

        public double CalculateTotalTax(ICompany company)
        {
            var citTax = company.GetCit(CountryId);
            var vatTax = company.GetDomesticVat(CountryId);

            var result = (citTax + vatTax) * 0.86 + AdditionalUeTax;

            return result;
        }

        public void PrepareInitialData(ICompany company)
        {

        }
    }
}
