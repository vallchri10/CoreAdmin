using System.Net;

namespace CorePractice.Domain.ExceptionModels
{
    public class ConflictException : BaseCustomException
    {
        public ConflictException(string message, string description) : base(message, description, (int)HttpStatusCode.Conflict)
        {
        }
    }
}
