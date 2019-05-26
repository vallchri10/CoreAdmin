using AutoMapper;
using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using CorePractice.Domain.ExceptionModels;
using CorePractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorePractice.Data.DataServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly CoreContext _context;
        private readonly IMapper _mapper;

        public UserService(CoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public void User_Create(User UserDomain, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            SQLParameters.UserID.Value = UserDomain.UserID;
            SQLParameters.UserRole.Value = UserDomain.UserRole;
            SQLParameters.FirstName.Value = UserDomain.FirstName;
            SQLParameters.LastName.Value = UserDomain.LastName;
            SQLParameters.Username.Value = UserDomain.Username;
            SQLParameters.PasswordHash.Value = passwordHash;
            SQLParameters.PasswordSalt.Value = passwordSalt;

            _context.Database.ExecuteSqlCommand(
               SQLCommands.User_Create,
               SQLParameters.UserID,
               SQLParameters.UserRole,
               SQLParameters.FirstName,
               SQLParameters.LastName,
               SQLParameters.Username,
               SQLParameters.PasswordHash,
               SQLParameters.PasswordSalt);
        }

        public IEnumerable<User> GetAll()
        {
            var Result = _context.Users.ToList();
            var omg = Result.Select(x =>
            {
                x.PasswordHash = null;
                x.PasswordSalt = null;
                return x; 
            });

            return  _mapper.Map<IEnumerable<User>>(omg);
        }


        public User GetById(string id)
        {
            var Result = _context.Users.Find(id);
            return _mapper.Map<User>(Result);
        }


        public User Authenticate(string username, string password)
        {
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //    return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            //return user;
            return _mapper.Map<User>(user);
        }






    }
}
