using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Interfaces.Interfaces
{
    public interface IUserService
    {
        UserEntity GetById(int id);
        UserEntity GetByEmail(string email);
        UserEntity CreateUser(UserEntity entity);
        UserEntity UpdateUser(UserEntity entity);
        void DeleteUser(int id);

    }
}
