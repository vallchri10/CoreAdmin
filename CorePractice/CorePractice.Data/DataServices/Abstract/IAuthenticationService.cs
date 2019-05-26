using CorePractice.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePractice.Data.DataServices.Abstract
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password); 
    }
}
