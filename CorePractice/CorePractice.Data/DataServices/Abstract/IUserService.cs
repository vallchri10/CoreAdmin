using CorePractice.Domain.DataModels;
using System.Collections.Generic;

namespace CorePractice.Data.DataServices.Abstract
{
    public interface IUserService
    {
        void User_Create(User user, string password);
        IEnumerable<User> Users_Read(); 



        User GetById(string id); 

    }
}
