using System.Net;

namespace CoreAdmin.Domain.ExceptionModels
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message, string description) : base(message, description, (int)HttpStatusCode.Conflict){}
    }
}
