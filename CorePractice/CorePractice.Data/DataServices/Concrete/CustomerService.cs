using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using AutoMapper;
using CorePractice.Domain.Models;
using System;

namespace CorePractice.Data.DataServices.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly CoreContext _context;
        private readonly IMapper _mapper;


        public CustomerService(CoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public async Task<List<Customer>> Customers_Read()
        {
            var Result = await _context.Set<CustomerEntity>().FromSql(SPCommands.Customers_Read).ToListAsync();
            return _mapper.Map<List<Customer>>(Result);
        }

        public async Task<Customer> Customer_Read(string CustomerID)
        {
            var ParameterizedCustomerID = new SqlParameter("@CustomerID", CustomerID);
            var ParameterizedReturnCode = new SqlParameter("@ReturnCode", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var Result = await _context.Set<CustomerEntity>().FromSql(SPCommands.Customer_Read, ParameterizedCustomerID, ParameterizedReturnCode).FirstOrDefaultAsync();
            var ReturnCode = ParameterizedReturnCode.Value.ToString();

            return _mapper.Map<Customer>(Result);
        }

        public async Task Customer_Create(Customer CustomerDomain)
        {
            var CustomerID = new SqlParameter("@CustomerID", CustomerDomain.CustomerID);
            var FirstName = new SqlParameter("@FirstName", CustomerDomain.FirstName);
            var LastName = new SqlParameter("@LastName", CustomerDomain.LastName);
            var DateOfBirth = new SqlParameter("@DateOfBirth", CustomerDomain.DateOfBirth);
            var Address = new SqlParameter("@Address", CustomerDomain.Address);

            try
            {
                _context.Database.ExecuteSqlCommandAsync(SPCommands.Customer_Create,CustomerID, FirstName, LastName, DateOfBirth, Address).Wait(); 
            }
            catch(Exception ex)
            {
                throw new DbUpdateException("test",ex);
            }
        }
    }
}
