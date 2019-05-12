using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using CorePractice.Domain.Models;

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

        public async Task<IEnumerable<Customer>> Customers_Read()
        {
            var Result = await _context.Set<CustomerEntity>().FromSql(
                SPCommands.Customers_Read).ToListAsync();

            return _mapper.Map<List<Customer>>(Result);
        }

        public async Task<Customer> Customer_Read(string CustomerID)
        {
            SPParameters.CustomerID.Value = CustomerID;

            var Result = await _context.Set<CustomerEntity>().FromSql(
                SPCommands.Customer_Read,
                SPParameters.CustomerID,
                SPParameters.ReturnCode)
                .FirstOrDefaultAsync();

            var ReturnCode = SPParameters.ReturnCode.Value.ToString();

            return _mapper.Map<Customer>(Result);
        }

        public async Task Customer_Create(Customer CustomerDomain)
        {
            SPParameters.CustomerID.Value = CustomerDomain.CustomerID;
            SPParameters.FirstName.Value = CustomerDomain.FirstName;
            SPParameters.LastName.Value = CustomerDomain.LastName;
            SPParameters.DateOfBirth.Value = CustomerDomain.DateOfBirth;
            SPParameters.Address.Value = CustomerDomain.Address;

            await _context.Database.ExecuteSqlCommandAsync(
                SPCommands.Customer_Create, 
                SPParameters.CustomerID, 
                SPParameters.FirstName, 
                SPParameters.LastName, 
                SPParameters.DateOfBirth,
                SPParameters.Address);
        }

        public async Task Customer_Update(Customer CustomerDomain)
        {
            SPParameters.CustomerID.Value = CustomerDomain.CustomerID;
            SPParameters.FirstName.Value = CustomerDomain.FirstName;
            SPParameters.LastName.Value = CustomerDomain.LastName;
            SPParameters.DateOfBirth.Value = CustomerDomain.DateOfBirth; 
            SPParameters.Address.Value = CustomerDomain.Address; 

            await _context.Database.ExecuteSqlCommandAsync(
                SPCommands.Customer_Update, 
                SPParameters.CustomerID, 
                SPParameters.FirstName, 
                SPParameters.LastName, 
                SPParameters.DateOfBirth,
                SPParameters.Address, 
                SPParameters.ReturnCode);

            var ReturnCode = SPParameters.ReturnCode.Value.ToString();
        }

        public async Task<Customer> Customer_Delete (string CustomerID)
        {
            SPParameters.CustomerID.Value = CustomerID;

            var Result = await _context.Set<CustomerEntity>().FromSql(
                SPCommands.Customer_Delete,
                SPParameters.CustomerID,
                SPParameters.ReturnCode)
                .FirstOrDefaultAsync();

            var ReturnCode = SPParameters.ReturnCode.Value.ToString();

            return _mapper.Map<Customer>(Result);
        }
    }
}