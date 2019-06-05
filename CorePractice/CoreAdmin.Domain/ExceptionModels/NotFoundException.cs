using System.Net;

namespace CoreAdmin.Domain.ExceptionModels
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
