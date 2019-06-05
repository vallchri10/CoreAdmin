using System.Net;

namespace CoreAdmin.Domain.ExceptionModels
{
    public class ConflictException : BaseCustomException
    {
        public ConflictException(string message, string description) : base(message, description, (int)HttpStatusCode.Conflict)
        {
        }
    }
}
