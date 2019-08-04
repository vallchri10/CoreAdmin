using CoreAdmin.Repository.Entities;

using Microsoft.EntityFrameworkCore;

namespace CoreAdmin.Repository
{
    public partial class CoreContext : DbContext
    {
        public CoreContext()
        {
        }

        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerEntity> Customers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

        //    modelBuilder.Entity<CustomerEntity>(entity =>
        //    {
        //        entity.HasKey(e => e.CustomerId);

        //        entity.Property(e => e.CustomerId)
        //            .HasColumnName("CustomerID")
        //            .HasMaxLength(10)
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Address).HasMaxLength(50);

        //        entity.Property(e => e.City).HasMaxLength(50);

        //        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        //        entity.Property(e => e.FirstName).HasMaxLength(50);

        //        entity.Property(e => e.LastName).HasMaxLength(50);

        //        entity.Property(e => e.State).HasMaxLength(50);

        //        entity.Property(e => e.ZipCode).HasMaxLength(15);
        //    });
        //}
    }
}