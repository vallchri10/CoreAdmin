using System.Net;

namespace CoreAdmin.Domain.ExceptionModels
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound){}
    }
}
