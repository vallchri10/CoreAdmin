using AutoMapper;
using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using CorePractice.Data.Utilities;
using CorePractice.Domain.ExceptionModels;
using CorePractice.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CorePractice.Data.Entities; 

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