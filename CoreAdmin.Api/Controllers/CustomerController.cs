using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;

using CoreAdmin.Repository.Abstract;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Domain.ExceptionModels;

namespace CoreAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> CustomersRead()
        {
           return await _customerRepository.Customers_Read();
        }

        [HttpGet, Route("{CustomerID}")]
        public async Task<ActionResult<Customer>> CustomerRead(string CustomerID)
        {
            try
            {
                return await _customerRepository.Customer_Read(CustomerID);
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
                await _customerRepository.Customer_Create(CustomerDomain);
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
                throw new BadRequestException("Bad Request", "Check request data and resend.");
            }

            try
            {
                await _customerRepository.Customer_Update(CustomerDomain);

                return NoContent();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50001)
                {
                    throw new NotFoundException(ex.Message, $"Customer with ID {CustomerID} does not exist.");
                }

                throw;
            }
        }

        [HttpDelete("{CustomerID}")]
        public async Task<IActionResult> CustomerDelete(string CustomerID)
        {
            try
            {
                await _customerRepository.Customer_Delete(CustomerID);

                return NoContent(); 
            }
            catch (SqlException ex)
            {
                if (ex.Number == 51000)
                {
                    throw new NotFoundException(ex.Message, $"Customer with ID {CustomerID} does not exist.");
                }

                throw;
            }
        }
    }
}