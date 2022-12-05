using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankManager.Services
{
    public class UserService : IUserService
    {
        public IBankManagerContext Context { get; }

        public UserService(IBankManagerContext bankManagerContext)
        {
            Context = bankManagerContext;
        }

        public UserEntity GetById(int id)
        {
            var result = Context.Users.Include(x => x.Approvements).FirstOrDefault(x => x.Id == id);
            return result;
        }

        public UserEntity GetByEmail(string email)
        {
            var result = Context.Users.FirstOrDefault(x => x.Email == email);
            return result;
        }

        public UserEntity CreateUser(UserEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            Context.Users.Add(entity);
            Context.SaveChanges();

            var savedEntity = Context.Users.FirstOrDefault(x => x.Id == entity.Id);
            return savedEntity;
        }

        public UserEntity UpdateUser(UserEntity entity)
        {
            var toUpdate = Context.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException("For given Id user entity not found");
            }

            toUpdate.FirstName = entity.FirstName;
            toUpdate.LastName = entity.LastName;
            toUpdate.Birthday = entity.Birthday;
            toUpdate.Email = entity.Email;
            toUpdate.IsContractor = entity.IsContractor;

            Context.SaveChanges();
            var updatedEntity = Context.Users.FirstOrDefault(x => x.Id == entity.Id);
            return updatedEntity;

        }

        public void DeleteUser(int userId)
        {
           var toDelete = Context.Users.FirstOrDefault(x => x.Id == userId);

            if(toDelete == null)
            {
                throw new ArgumentException("For given Id user entity not found");
            }

            toDelete.DeletionDate = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
