using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreAdmin.Website.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerListing()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomerUpdate()
        {
            return PartialView("_Customer_Update");
        }
    }
}