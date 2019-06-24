using System;
using System.Collections.Generic;

namespace CoreAdmin.Repository.Entities
{
    public partial class EmployeesEntity
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
