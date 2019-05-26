using AutoMapper;

using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using CorePractice.Domain.DataModels;
using CorePractice.Data.Utilities;
using System.Linq;

namespace CorePractice.Data.DataServices.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly CoreContext _context;
        private readonly IMapper _mapper;

        public AuthenticationService(CoreContext context, IMapper mapper)
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
