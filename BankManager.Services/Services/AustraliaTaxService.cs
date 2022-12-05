using BankManager.Entities.Interfaces;
using BankManager.Services.Interfaces;

namespace BankManager.Services
{
    public class AustraliaTaxService : ITaxService
    {
        public int CountryId { get; set; }
        public double AdditionalTax { get; set; }
        public double AnotherAdditionalTax { get; set; }

        public double ApplyBenefit(ICompany company)
        {
            return 0.95;
        }

        public double ApplySpecialCompanyTax(ICompany company)
        {
            return 0;
        }

        public double CalculateTotalTax(ICompany company)
        {
            var citTax = company.GetCit(CountryId);
            var vatTax = company.GetDomesticVat(CountryId);

            var result = (citTax + vatTax) * 0.86 + AdditionalTax + 0.99 * AnotherAdditionalTax;

            return result;
        }

        public void PrepareInitialData(ICompany company)
        {

        }
    }
}
