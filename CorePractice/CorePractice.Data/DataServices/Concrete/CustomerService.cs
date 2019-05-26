using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataSources;
using CorePractice.Domain.DataModels;
using CorePractice.Data.Entities;
using CorePractice.Data.Utilities;

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
                SQLCommands.Customers_Read).ToListAsync();

            return _mapper.Map<List<Customer>>(Result);
        }

        public async Task<Customer> Customer_Read(string CustomerID)
        {
            SQLParameters.CustomerID.Value = CustomerID;

            var Result = await _context.Set<CustomerEntity>().FromSql(
                SQLCommands.Customer_Read,
                SQLParameters.CustomerID)
                .FirstOrDefaultAsync();

            return _mapper.Map<Customer>(Result);
        }

        public async Task Customer_Create(Customer CustomerDomain)
        {
            SQLParameters.CustomerID.Value = CustomerDomain.CustomerID;
            SQLParameters.FirstName.Value = CustomerDomain.FirstName;
            SQLParameters.LastName.Value = CustomerDomain.LastName;
            SQLParameters.DateOfBirth.Value = CustomerDomain.DateOfBirth;
            SQLParameters.Address.Value = CustomerDomain.Address;

            await _context.Database.ExecuteSqlCommandAsync(
                SQLCommands.Customer_Create, 
                SQLParameters.CustomerID, 
                SQLParameters.FirstName, 
                SQLParameters.LastName, 
                SQLParameters.DateOfBirth,
                SQLParameters.Address);
        }

        public async Task Customer_Update(Customer CustomerDomain)
        {
            SQLParameters.CustomerID.Value = CustomerDomain.CustomerID;
            SQLParameters.FirstName.Value = CustomerDomain.FirstName;
            SQLParameters.LastName.Value = CustomerDomain.LastName;
            SQLParameters.DateOfBirth.Value = CustomerDomain.DateOfBirth; 
            SQLParameters.Address.Value = CustomerDomain.Address; 

            await _context.Database.ExecuteSqlCommandAsync(
                SQLCommands.Customer_Update, 
                SQLParameters.CustomerID, 
                SQLParameters.FirstName, 
                SQLParameters.LastName, 
                SQLParameters.DateOfBirth,
                SQLParameters.Address, 
                SQLParameters.ReturnCode);
        }

        public async Task<Customer> Customer_Delete (string CustomerID)
        {
            SQLParameters.CustomerID.Value = CustomerID;

            var Result = await _context.Set<CustomerEntity>().FromSql(
                SQLCommands.Customer_Delete,
                SQLParameters.CustomerID,
                SQLParameters.ReturnCode)
                .FirstOrDefaultAsync();

            var ReturnCode = SQLParameters.ReturnCode.Value.ToString();

            return _mapper.Map<Customer>(Result);
        }
    }
}