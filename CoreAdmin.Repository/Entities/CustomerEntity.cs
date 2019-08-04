using System;
using System.ComponentModel.DataAnnotations;

namespace CoreAdmin.Repository.Entities
{
    public partial class CustomerEntity
    {
        [Key]
        public string CustomerId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}




//modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

//            modelBuilder.Entity<CustomerEntity>(entity =>
//            {
//                entity.HasKey(e => e.CustomerId);

//                entity.Property(e => e.CustomerId)
//                    .HasColumnName("CustomerID")
//                    .HasMaxLength(10)
//                    .ValueGeneratedNever();

//entity.Property(e => e.Address).HasMaxLength(50);

//entity.Property(e => e.City).HasMaxLength(50);

//entity.Property(e => e.DateOfBirth).HasColumnType("date");

//entity.Property(e => e.FirstName).HasMaxLength(50);

//entity.Property(e => e.LastName).HasMaxLength(50);

//entity.Property(e => e.State).HasMaxLength(50);

//entity.Property(e => e.ZipCode).HasMaxLength(15);
//            });