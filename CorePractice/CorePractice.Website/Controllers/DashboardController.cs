﻿using Microsoft.AspNetCore.Mvc;

namespace CorePractice.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OpenCreatePartial()
        {
            return PartialView("_CreatePartial");
        }

        [HttpGet]
        public IActionResult OpenReadPartial()
        {
            return PartialView("_ReadPartial");
        }
    }
}