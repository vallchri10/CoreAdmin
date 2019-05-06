﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CorePractice.Api.Models
{
    public partial class CoreEntities : DbContext
    {
        public CoreEntities()
        {
        }

        public CoreEntities(DbContextOptions<CoreEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ISMAELRIG;Database=CoreDatabase; Integrated Security=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });
        }
    }
}
