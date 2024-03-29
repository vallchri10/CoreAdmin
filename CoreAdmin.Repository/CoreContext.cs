﻿using CoreAdmin.Repository.Entities;

using Microsoft.EntityFrameworkCore;

namespace CoreAdmin.Repository
{
    public partial class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerEntity> Customers { get; set; }

        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth);



            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserID)
                 .HasColumnName("UserID")
                 .HasMaxLength(10)
                 .ValueGeneratedNever();

                entity.Property(e => e.UserRole).HasMaxLength(10);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(4000);

                entity.Property(e => e.PasswordSalt).HasMaxLength(4000);

            });
        }
    }
}