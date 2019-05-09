using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

using CorePractice.Data.DataSources;
using CorePractice.Data.DataServices.Abstract;

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
        public async Task<ActionResult<List<CustomerEntity>>> Customers_Read()
        {
           return await _customerService.Customers_Read(); 

        }

        [HttpGet("{CustomerID}")]
        public async Task<ActionResult<CustomerEntity>> Customer_Read(string CustomerID)
        {
            return await _customerService.Customer_Read(CustomerID); 
        }
    }
}