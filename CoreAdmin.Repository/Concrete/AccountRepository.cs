using CoreAdmin.Repository.Abstract;
using CoreAdmin.Repository.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAdmin.Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        private SignInManager<IdentityUser> _signManager;
        private UserManager<User> _userManager;

        public AccountRepository()
        {

        }



        
        public void Register_Employee()
        {

        }

        //public void (User UserDomain, string password)
        //{
        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new AppException("Password is required");

        //    byte[] passwordHash, passwordSalt;
        //    PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    SQLParameters.UserID.Value = UserDomain.UserID;
        //    Utilities.SQLParameters.UserRole.Value = UserDomain.UserRole;
        //    SQLParameters.FirstName.Value = UserDomain.FirstName;
        //    Utilities.SQLParameters.LastName.Value = UserDomain.LastName;
        //    SQLParameters.Username.Value = UserDomain.Username;
        //    SQLParameters.PasswordHash.Value = passwordHash;
        //    SQLParameters.PasswordSalt.Value = passwordSalt;

        //    _context.Database.ExecuteSqlCommand(
        //       SQLCommands.User_Create,
        //       SQLParameters.UserID,
        //       SQLParameters.UserRole,
        //       SQLParameters.FirstName,
        //       SQLParameters.LastName,
        //       SQLParameters.Username,
        //       SQLParameters.PasswordHash,
        //       SQLParameters.PasswordSalt);
        //}
    }
}
