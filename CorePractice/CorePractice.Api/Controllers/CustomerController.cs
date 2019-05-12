using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

using CorePractice.Data.DataServices.Abstract;
using CorePractice.Domain.Models;
using System.Data.SqlClient;

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
        public async Task<IEnumerable<Customer>> Customers_Read()
        {
           return await _customerService.Customers_Read(); 

        }

        [HttpGet("{CustomerID}")]
        public async Task<Customer> Customer_Read(string CustomerID)
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
            catch (SqlException)
            {
                return Conflict(new { message = $"An existing record with the id '{CustomerDomain.CustomerID}' was already found." });
            }
            return CreatedAtAction("Customer_Read", new { CustomerDomain.CustomerID }, CustomerDomain);
        }

        [HttpPut("{CustomerID}")]
        public async Task<IActionResult> Customer_Update(string CustomerID, Customer CustomerDomain)
        {
            if (CustomerID != CustomerDomain.CustomerID)
            {
                return BadRequest();
            }

            try
            {
                await _customerService.Customer_Update(CustomerDomain); 
            }
            catch (SqlException ex)
            {
                if (ex.Number == 51000)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{CustomerID}")]
        public async Task<ActionResult<Customer>> Customer_Delete(string CustomerID)
        {
            try
            {
                var Result = await _customerService.Customer_Delete(CustomerID);
                return Result;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 51000)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }          
        }
    }
}