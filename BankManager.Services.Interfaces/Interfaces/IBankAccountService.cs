using BankManager.Entities;
using BankManager.Entities.SearchCriteriaModels;


namespace BankManager.Services.Interfaces.Interfaces
{
    public interface IBankAccountService
    {
        BankAccountEntity GetById(int id);
        List<BankAccountEntity> GetAll();
        List<BankAccountEntity> GetFiltered(BankAccountSearchCriteria searchCriteria);

        BankAccountEntity CreateAccount(BankAccountEntity entity);
        BankAccountEntity UpdateAccount(BankAccountEntity entity);
        void DeleteAccount(int bankAccountId);
    }
}
