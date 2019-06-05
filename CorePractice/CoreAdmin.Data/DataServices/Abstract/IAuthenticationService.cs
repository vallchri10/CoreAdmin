using CoreAdmin.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAdmin.Data.DataServices.Abstract
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
