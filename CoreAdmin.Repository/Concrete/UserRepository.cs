using AutoMapper;
using CoreAdmin.Repository.Abstract;
using CoreAdmin.Repository.Utilities;
using CoreAdmin.Domain.ExceptionModels;
using CoreAdmin.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CoreAdmin.Repository.Entities;

namespace CoreAdmin.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreContext _context;
        private readonly IMapper _mapper;

        public UserRepository(CoreContext context, IMapper mapper)
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

        public IEnumerable<User> Users_Read()
        {
            return _mapper.Map<List<User>>(
                _context.Users.FromSql(SQLCommands.Users_Read).ToList());
        }


        public User GetById(string id)
        {
            var Result = _context.Users.Find(id);
            return _mapper.Map<User>(Result);
        }




    }
}