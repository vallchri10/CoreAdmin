using System;

namespace CorePractice.Data.DataSources
{
    public partial class CustomerEntity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
