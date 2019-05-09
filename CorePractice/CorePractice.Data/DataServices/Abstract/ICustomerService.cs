using CorePractice.Data.DataSources;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePractice.Domain.Models; 

namespace CorePractice.Data.DataServices.Abstract
{
    public interface ICustomerService
    {
        Task<List<Customer>> Customers_Read();
        Task<Customer> Customer_Read(string CustomerID);
        Task Customer_Create(Customer CustomerDomain); 
    }
}
