using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using CorePractice.Data.DataSources;

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
        public async Task<ActionResult<List<Customers>>> Customers_Read()
        {
            const string SQL_COMMAND = "EXEC [dbo].[Customers_Read]";
            return await _context.Set<Customers>().FromSql(SQL_COMMAND).ToListAsync();
        }

        [HttpGet("{CustomerID}")]
        public ActionResult Customer_Read(string CustomerID)
        {
            var ParameterizedCustomerID = new SqlParameter("@CustomerID", CustomerID);
            var ParameterizedROWCOUNT = new SqlParameter("@ROWCOUNT", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };
            const string SQL_COMMAND = "EXEC [dbo].[Customer_Read] @CustomerID, @ROWCOUNT OUTPUT";
            var Result = _context.Set<Customers>().FromSql(SQL_COMMAND, ParameterizedCustomerID, ParameterizedROWCOUNT).FirstOrDefault();
            var ROWCOUNT = ParameterizedROWCOUNT.Value.ToString();
            return Ok(Result);
        }
    }
}