using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Entities.SearchCriteriaModels;
using BankManager.Services.Interfaces;
using BankManager.Services.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services
{
    public class BankAccountService : IBankAccountService
    {
        public IBankManagerContext Context { get; }

        public BankAccountService(IBankManagerContext bankManagerContext)
        {
            Context = bankManagerContext;
        }

        public BankAccountEntity GetById(int id)
        {
            return Context.BankAccounts.FirstOrDefault(x => x.Id == id);
        }

        public List<BankAccountEntity> GetAll()
        {
            return Context.BankAccounts.ToList();
        }

        public List<BankAccountEntity> GetFiltered(BankAccountSearchCriteria searchCriteria)
        {
            var result = Context.BankAccounts.AsQueryable();

            if (searchCriteria == null)
            {
                throw new ArgumentNullException("searchCriteria");
            }

            if (searchCriteria.BankId.HasValue)
            {
                result = result.Where(x => x.BankId == searchCriteria.BankId.Value);
            }

            if (searchCriteria.BalanceFrom.HasValue)
            {
                result = result.Where(x => x.Balance >= searchCriteria.BalanceFrom.Value);
            }

            if (searchCriteria.BalanceTo.HasValue)
            {
                result = result.Where(x => x.Balance <= searchCriteria.BalanceTo.Value);
            }

            if (searchCriteria.InterestFrom.HasValue)
            {
                result = result.Where(x => x.Interest >= searchCriteria.InterestFrom.Value);
            }

            if (searchCriteria.InterestTo.HasValue)
            {
                result = result.Where(x => x.Interest <= searchCriteria.InterestTo.Value);
            }

            if (searchCriteria.CurrencyId.HasValue)
            {
                result = result.Where(x => x.CurrencyId <= searchCriteria.CurrencyId.Value);
            }

            return result.ToList();
        }

        public BankAccountEntity CreateAccount(BankAccountEntity entity)
        {
            try
            {
                entity.CreationDate = DateTime.Now;

                Context.BankAccounts.Add(entity);
                Context.SaveChanges();

                var savedEntity = Context.BankAccounts.FirstOrDefault(x => x.Id == entity.Id);

                return savedEntity;
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        public BankAccountEntity UpdateAccount(BankAccountEntity entity)
        {
            var toUpdate = Context.BankAccounts.FirstOrDefault(x => x.Id == entity.Id);

            if (toUpdate == null)
            {
                throw new ArgumentException("For given Id bank account entity not found");
            }

            toUpdate.Number = entity.Number;
            toUpdate.BankId = entity.BankId;
            toUpdate.Balance = entity.Balance;
            toUpdate.Interest = entity.Interest;
            toUpdate.LastModificationDate = DateTime.Now;
            toUpdate.CurrencyId = entity.CurrencyId;

            Context.SaveChanges();

            var savedEntity = Context.BankAccounts.FirstOrDefault(x => x.Id == entity.Id);

            return savedEntity;
        }

        public void DeleteAccount(int bankAccountId)
        {
            var toDelete = Context.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            if (toDelete == null)
            {
                throw new ArgumentException("For given Id bank account entity not found");
            }

            toDelete.DeletionDate = DateTime.Now;

            Context.SaveChanges();
        }

        
    }

    
}