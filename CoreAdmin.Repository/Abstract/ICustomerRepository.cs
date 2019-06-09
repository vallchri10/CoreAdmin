using System.Collections.Generic;
using System.Threading.Tasks;

using CoreAdmin.Domain.DataModels;

namespace CoreAdmin.Repository.Abstract
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Customers_Read();
        Task<Customer> Customer_Read(string CustomerID);
        Task Customer_Create(Customer CustomerDomain);
        Task Customer_Update(Customer CustomerDomain);
        Task Customer_Delete(string CustomerID);
    }
}