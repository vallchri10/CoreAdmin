﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAdmin.Domain.ExceptionModels
{
    public class CustomErrorResponse
    {
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
