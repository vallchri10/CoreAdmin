using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAdmin.Domain.DataModels
{
    public class Employees
    {
        public string UserID { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
