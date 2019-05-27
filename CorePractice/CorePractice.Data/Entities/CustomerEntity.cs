using System;
namespace CorePractice.Data.Entities
{
    public partial class CustomerEntity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}