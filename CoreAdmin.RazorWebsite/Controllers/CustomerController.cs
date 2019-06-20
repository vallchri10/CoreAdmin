using Microsoft.AspNetCore.Mvc;

namespace CoreAdmin.RazorWebsite.Controllers
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