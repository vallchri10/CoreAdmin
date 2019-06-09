using CoreAdmin.Domain.DataModels;

namespace CoreAdmin.Repository.Abstract
{
    public interface IAuthenticationRepository
    {
        User Authenticate(string username, string password);
    }
}