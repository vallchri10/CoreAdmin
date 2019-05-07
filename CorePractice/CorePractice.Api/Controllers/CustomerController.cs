using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using CorePractice.Data.DataSources;
using Microsoft.EntityFrameworkCore;

namespace CorePractice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CoreEntities _context; 

        public CustomerController(CoreEntities context)
        {
            _context = context; 
        }




        [HttpGet]
        public ActionResult Customer_ReadAll()
        {
            var nice = _context.Customers.ToList();
            return Ok(nice);
                


            //using (CoreEntities db = new CoreEntities())
            //{
            //    return Ok(db.Customers.ToList()); 
            //}
        }

        //[HttpGet("{CustomerID}")]
        //public ActionResult Customer_Read(string CustomerID)
        //{
        //    //using (CoreEntities db = new CoreEntities())
        //    //{
        //    //    return Ok(db.Customers.Find(CustomerID));
        //    //}
        //}
    }
}
