using System.Net;

namespace CorePractice.Domain.ExceptionModels
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
