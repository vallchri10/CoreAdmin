using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;

using CoreAdmin.Data.DataServices.Abstract;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Domain.ExceptionModels;

namespace CoreAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> CustomersRead()
        {
           return await _customerService.Customers_Read();
        }

        [HttpGet, Route("{CustomerID}")]
        public async Task<ActionResult<Customer>> CustomerRead(string CustomerID)
        {
            try
            {
                return await _customerService.Customer_Read(CustomerID);
            }
            catch(SqlException ex)
            {
                throw new NotFoundException(ex.Message, $"Customer with ID {CustomerID} does not exist.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CustomerCreate([FromBody]Customer CustomerDomain)
        {
            try
            {
                await _customerService.Customer_Create(CustomerDomain);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50001)
                {
                    throw new ConflictException(ex.Message, $"Customer {CustomerDomain.CustomerID} already exists.");
                }

                throw; 
            }
            return CreatedAtAction("CustomerRead", new { CustomerDomain.CustomerID }, CustomerDomain);
        }

        [HttpPut, Route("{CustomerID}")]
        public async Task<IActionResult> CustomerUpdate([FromRoute]string CustomerID, [FromBody]Customer CustomerDomain)
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
                if (ex.Number == 50001)
                {
                    throw new NotFoundException(ex.Message, $"Customer with ID {CustomerID} does not exist.");
                }

                throw;
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