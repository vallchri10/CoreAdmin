using CoreAdmin.Domain.DataModels;
using System.Collections.Generic;

namespace CoreAdmin.Repository.Abstract
{
    public interface IUserRepository
    {
        void User_Create(User user, string password);
        IEnumerable<User> Users_Read();



        User GetById(string id);

    }
}
