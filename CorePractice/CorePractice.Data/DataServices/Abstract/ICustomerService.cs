using CorePractice.Data.DataSources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePractice.Data.DataServices.Abstract
{
    public interface ICustomerService
    {
        Task<List<Customers>> Customers_Read();
        Task<Customers> Customer_Read(string CustomerID); 
    }
}
