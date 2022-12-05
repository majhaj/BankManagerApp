using BankManager.Entities.Interfaces;

namespace BankManager.BusinessModels
{
    public class SmallCompany : ICompany
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public double Income { get; set; }

        public double GetCit(int companyCountrId)
        {
            return 500;
        }

        public double GetDomesticVat(int companyCountrId)
        {
            if (companyCountrId == 0)
            {
                return 3.5;
            }
            else
            {
                return 4.5;
            }
        }
    }
}
