using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsitePractice.Models;

namespace WebsitePractice.Controllers
{
    public class HomeController : Controller
    {
        CustomerService db = new CustomerService();

        [HttpGet]
        public IActionResult getAllCustomers()
        {
            return Json(db.getAllCustomers().ToArray());
        }

        [HttpGet]
        public IActionResult getCertainCustomer(int? id)
        {
            if (!id.HasValue)
            {
                return Json("Not Found");
            }
            else
            {
                return Json(db.getCertainCustomer(id));
            }
        }

        [HttpPost]
        public IActionResult CreatePerson(Customer newCustomer)
        {
            db.addCustomer(newCustomer);
            return CreatedAtAction(nameof(newCustomer), new { id = newCustomer.customerId }, newCustomer);
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







        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
