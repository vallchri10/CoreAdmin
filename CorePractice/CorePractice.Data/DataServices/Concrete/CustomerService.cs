using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CorePractice.Data.DataServices.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly CoreContext _context;

        public CustomerService(CoreContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntity>> Customers_Read()
        { 
           return await _context.Set<CustomerEntity>().FromSql(SPCommands.Customers_Read).ToListAsync();
        }

        public async Task<CustomerEntity> Customer_Read(string CustomerID)
        {
            var ParameterizedCustomerID = new SqlParameter("@CustomerID", CustomerID);
            var ParameterizedReturnCode = new SqlParameter("@ReturnCode", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var Result = await _context.Set<CustomerEntity>().FromSql(SPCommands.Customer_Read, ParameterizedCustomerID, ParameterizedReturnCode).FirstOrDefaultAsync();
            var ReturnCode = ParameterizedReturnCode.Value.ToString();

            return Result; 
        }
    }
}
