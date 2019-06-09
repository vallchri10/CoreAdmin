using AutoMapper;

using CoreAdmin.Repository.Abstract;
using CoreAdmin.Repository;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Repository.Utilities;
using System.Linq;

namespace CoreAdmin.Repository.Concrete
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CoreContext _context;
        private readonly IMapper _mapper;

        public AuthenticationRepository(CoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);


            if (user == null)
                return null;


            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<User>(user);
        }
    }
}
