using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsitePractice.Models
{
    public class CustomerService
    {
        public static List<Customer> db = new List<Customer>();

        public CustomerService()
        {
            db.Add(new Customer { customerId = 1, firstName = "Bob", lastName = "Smith", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 2, firstName = "Zena", lastName = "Bauch", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 3, firstName = "John", lastName = "Legros", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 4, firstName = "Vivien", lastName = "Hodkiewicz", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 5, firstName = "Robb", lastName = "Lehner", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 5, firstName = "Robb", lastName = "Lehner", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 6, firstName = "Lonie", lastName = "McClure", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 7, firstName = "Sydni", lastName = "Konopelski", birthDate = DateTime.Now });
            db.Add(new Customer { customerId = 8, firstName = "Yesenia", lastName = "Hammes", birthDate = DateTime.Now });
        }

        public List<Customer> getAllCustomers()
        {
            return db.ToList(); 
        }

        public Customer getCertainCustomer(int? id)
        {
            return db.Where(x => x.customerId == id).FirstOrDefault(); 
        }

        public void addCustomer(Customer newCustomer)
        {
            db.Add(newCustomer);
        }
    }//end class
}
