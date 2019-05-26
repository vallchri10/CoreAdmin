using CorePractice.Data.DataSources;

using CorePractice.Domain.Models;
using System.Collections.Generic; 

namespace CorePractice.Data.DataServices.Abstract
{
    public interface IUserService
    {
        void User_Create(User user, string password); 
        User Authenticate(string username, string password); 





        IEnumerable<User> GetAll();


        User GetById(string id); 

    }
}
