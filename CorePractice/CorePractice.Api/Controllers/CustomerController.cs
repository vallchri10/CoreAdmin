using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

using CorePractice.Data.DataServices.Abstract;
using CorePractice.Domain.Models;

namespace CorePractice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Customers_Read()
        {
           return await _customerService.Customers_Read(); 

        }

        [HttpGet("{CustomerID}")]
        public async Task<ActionResult<Customer>> Customer_Read(string CustomerID)
        {
            return await _customerService.Customer_Read(CustomerID); 
        }

        [HttpPost]
        public async Task<IActionResult> Customer_Create([FromBody]Customer CustomerDomain)
        {
            try
            {
                await _customerService.Customer_Create(CustomerDomain);
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
            return CreatedAtAction("Customer_Read", new { CustomerID = CustomerDomain.CustomerID }, CustomerDomain);
        }
    }
}