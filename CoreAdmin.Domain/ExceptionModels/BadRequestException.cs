using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CoreAdmin.Domain.ExceptionModels
{

    public class BadRequestException : BaseException
    {
        public BadRequestException(string message, string description) : base(message, description, (int)HttpStatusCode.BadRequest) { }
    }
}
