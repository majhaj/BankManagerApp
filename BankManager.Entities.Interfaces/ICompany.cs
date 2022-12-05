namespace BankManager.Entities.Interfaces
{
    public interface ICompany
    {
        int CompanyId { get; set; }
        string Name { get; set; }
        double Income { get; set; }

        double GetDomesticVat(int companyCountrId);

        double GetCit(int companyCountrId);
    }
}
