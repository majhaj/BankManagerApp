using BankManager.Entities.Interfaces;

namespace BankManager.BusinessModels
{
    public class LargeCompany : ICompany
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public double Income { get; set; }

        public double GetCit(int companyCountrId)
        {
            return 300;
        }

        public double GetDomesticVat(int companyCountrId)
        {
            if (companyCountrId == 0)
            {
                return 1.5;
            }
            else
            {
                return 0.5;
            }
        }
    }
}
