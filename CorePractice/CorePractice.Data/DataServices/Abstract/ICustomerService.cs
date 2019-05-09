using CorePractice.Data.DataSources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePractice.Data.DataServices.Abstract
{
    public interface ICustomerService
    {
        Task<List<CustomerEntity>> Customers_Read();
        Task<CustomerEntity> Customer_Read(string CustomerID); 
    }
}
