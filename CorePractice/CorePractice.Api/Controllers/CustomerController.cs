using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using CorePractice.Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System;


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
            return Ok(_context.Customers.ToList());
        }

        [HttpGet("{CustomerID}")]
        public ActionResult Customer_Read(string CustomerID)
        {
            return Ok(_context.Customers.Find(CustomerID));
        }


        //[HttpGet, Route("niceOne/{CustomerID}")]
        //public ActionResult SP(string CustomerID)
        //{
        //    var Customer = _context.Customers.FromSql("[dbo].[Read] @p0", CustomerID)
        //    .FirstOrDefault();

        //    return Ok(Customer);
        //}

        [HttpGet, Route("niceOne/{CustomerID}")]
        public ActionResult SP(string CustomerID)
        {
            var Customer = _context.Customers.FromSql("[dbo].[Read] @p0", CustomerID)
            .FirstOrDefault();

            return Ok(Customer);
        }


    }
}
