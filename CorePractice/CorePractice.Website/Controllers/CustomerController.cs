﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CorePractice.Website.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerListing()
        {
            return View();
        }
    }
}