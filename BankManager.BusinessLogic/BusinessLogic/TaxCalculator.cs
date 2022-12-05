
using BankManager.Entities.Interfaces;
using BankManager.Services.Interfaces;

namespace BankManager.BusinessLogic
{
    public class TaxCalculator
    {
        public ICompany Company { get; set; }
        public double Calculate(ITaxService taxService)
        {
            taxService.PrepareInitialData(Company);
            var result = taxService.CalculateTotalTax(Company);

            result = result * taxService.ApplyBenefit(Company);

            result += taxService.ApplySpecialCompanyTax(Company);

            return result;
        }
    }
}
